
namespace _03._MinionNames
{
    public static class SqlQueries
    {
        public const string GetVillainNameById =
            @"SELECT Name FROM Villains WHERE Id = @Id";

        public const string GetAllMinionsByVillainId =
            @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) AS RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name";
    }
}
