﻿using System.Text;

using Microsoft.Data.SqlClient;

namespace _03._MinionNames
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            await using SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
            await sqlConnection.OpenAsync();

            int villainId = int.Parse(Console.ReadLine());
            string result = await GetVillainWithAllMinionsByIdAsync(sqlConnection, villainId);

            Console.WriteLine(result);
            sqlConnection.Close();
        }

        static async Task<string> GetVillainWithAllMinionsByIdAsync(SqlConnection sqlConnection, int villainId)
        {
            StringBuilder sb = new StringBuilder();

            SqlCommand getVillainNameCmd = new SqlCommand(SqlQueries.GetVillainNameById, sqlConnection);
            getVillainNameCmd.Parameters.AddWithValue("@Id", villainId);

            object? villainNameObj = await getVillainNameCmd.ExecuteScalarAsync();

            if (villainNameObj == null)
            {
                return $"No villain with ID {villainId} exists in the database.";
            }

            string villainName = (string)villainNameObj;

            SqlCommand getAllMinionsCmd = new SqlCommand(SqlQueries.GetAllMinionsByVillainId, sqlConnection);
            getAllMinionsCmd.Parameters.AddWithValue("@Id", villainId);

            SqlDataReader minionsReader = await getAllMinionsCmd.ExecuteReaderAsync();

            sb.AppendLine($"Villain: {villainName}");
            if (!minionsReader.HasRows)
            {
                sb.AppendLine("(no minions)");
            }
            else
            {
                while (minionsReader.Read())
                {
                    long rowNum = (long)minionsReader["RowNum"];
                    string minionName = (string)minionsReader["Name"];
                    int minionAge = (int)minionsReader["Age"];

                    sb.AppendLine($"{rowNum}. {minionName} {minionAge}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}