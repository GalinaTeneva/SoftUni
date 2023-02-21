using Microsoft.Data.SqlClient;
using System.Text;

namespace _04.AddMinion
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            await using SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
            await sqlConnection.OpenAsync();

            string[] minionArgs = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);
            string[] villainArgs = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);

            string result = await AddNewMinionsAsync(sqlConnection, minionArgs[1], villainArgs[1]);

            Console.WriteLine(result);
        }

        private static async Task<string> AddNewMinionsAsync(SqlConnection sqlConnection, string minionInfo, string villainName)
        {
            StringBuilder sb = new StringBuilder();

            string[] minionsArgs = minionInfo.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            string minionName = minionsArgs[0];
            int minionAge = int.Parse(minionsArgs[1]);
            string minionTown = minionsArgs[2];

            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

            try
            {
                int townId = await GetTownIdOrAddByNameAsync(sqlConnection, sqlTransaction, sb, minionTown);
                int villainId = await GetVillainIdOrAddByNameAsync(sqlConnection, sqlTransaction, sb, villainName);
                int minionId = await AddNewMinionAndReturnIdAsync(sqlConnection, sqlTransaction, minionName, minionAge, townId);

                await SetMinionToVillain(sqlConnection, sqlTransaction, minionId, villainId);

                sb.AppendLine($"Successfully added {minionName} to be minion of {villainName}.");

                await sqlTransaction.CommitAsync();
            }
            catch (Exception e)
            {
                await sqlTransaction.RollbackAsync();
                sb.AppendLine("Transaction Failed!");
            }

            return sb.ToString().TrimEnd();
        }

        private static async Task<int> GetTownIdOrAddByNameAsync(SqlConnection sqlConnection, SqlTransaction transaction, StringBuilder sb, string minionTown)
        {
            SqlCommand getTownIdCmd = new SqlCommand(SqlQueries.GetTownIdByName, sqlConnection,transaction);
            getTownIdCmd.Parameters.AddWithValue("@townName", minionTown);

            int? townId = (int?)await getTownIdCmd.ExecuteScalarAsync();
            if (!townId.HasValue)
            {
                SqlCommand addTownCmd = new SqlCommand(SqlQueries.AddNewTown, sqlConnection, transaction);
                addTownCmd.Parameters.AddWithValue("@townName", minionTown);

                await addTownCmd.ExecuteNonQueryAsync();
                townId = (int?)await getTownIdCmd.ExecuteScalarAsync();

                sb.AppendLine($"Town {minionTown} was added to the database.");
            }

            return townId.Value;
        }

        private static async Task<int> GetVillainIdOrAddByNameAsync(SqlConnection sqlConnection, SqlTransaction transaction, StringBuilder sb, string villainName)
        {
            SqlCommand getVillainIdCmd = new SqlCommand(SqlQueries.GetVillainIdByName, sqlConnection, transaction);
            getVillainIdCmd.Parameters.AddWithValue("@Name", villainName);

            int? villainId = (int?)await getVillainIdCmd.ExecuteScalarAsync();
            if (!villainId.HasValue)
            {
                SqlCommand addVillainCmd = new SqlCommand(SqlQueries.AddVillainWithDefaultEvilnessFactor, sqlConnection, transaction);
                addVillainCmd.Parameters.AddWithValue("@villainName", villainName);

                await addVillainCmd.ExecuteNonQueryAsync();

                villainId = (int?)await getVillainIdCmd.ExecuteScalarAsync();

                sb.AppendLine($"Villain {villainName} was added to the database.");
            }

            return villainId.Value;
        }

        private static async Task<int> AddNewMinionAndReturnIdAsync(SqlConnection sqlConnection, SqlTransaction transaction, string minionName, int minionAge, int townId)
        {
            SqlCommand addNewMinion = new SqlCommand(SqlQueries.AddNewMinion, sqlConnection, transaction);
            addNewMinion.Parameters.AddWithValue("@name", minionName);
            addNewMinion.Parameters.AddWithValue("@age", minionAge);
            addNewMinion.Parameters.AddWithValue("@townId", townId);

            await addNewMinion.ExecuteNonQueryAsync();

            SqlCommand getMinionIdCmd = new SqlCommand(SqlQueries.GetMinionIdByName, sqlConnection, transaction);
            getMinionIdCmd.Parameters.AddWithValue("@Name", minionName);

            int minionId = (int)await getMinionIdCmd.ExecuteScalarAsync();
            return minionId;
        }

        private static async Task SetMinionToVillain(SqlConnection sqlConnection, SqlTransaction transaction, int minnionId, int villainId)
        {
            SqlCommand addMinnionToVillainCmd = new SqlCommand(SqlQueries.SetMinionToVillain, sqlConnection, transaction);
            addMinnionToVillainCmd.Parameters.AddWithValue("@minionId", minnionId);
            addMinnionToVillainCmd.Parameters.AddWithValue("@villainId", villainId);

            await addMinnionToVillainCmd.ExecuteNonQueryAsync();
        }
    }
}