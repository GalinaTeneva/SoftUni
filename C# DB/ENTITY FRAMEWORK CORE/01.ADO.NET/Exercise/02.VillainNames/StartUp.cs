
using Microsoft.Data.SqlClient;
using System.Text;

namespace _02.VillainNames
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            await using SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
            await sqlConnection.OpenAsync();

            string result = await GetAllVillainsWithTheirMinionsAsync(sqlConnection);
            Console.WriteLine(result);

            sqlConnection.Close();
        }

        static async Task<string> GetAllVillainsWithTheirMinionsAsync(SqlConnection sqlConnection)
        {
            StringBuilder sb = new StringBuilder();

            SqlCommand sqlCommand = new SqlCommand(SqlQueries.GetAllVillainsAndTheirMinions, sqlConnection);
            SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

            while (reader.Read())
            {
                string villainName = (string)reader["Name"];
                int minionsCount = (int)reader["MinionsCount"];

                sb.AppendLine($"{villainName} - {minionsCount}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}