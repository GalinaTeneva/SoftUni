using MiniORM.App.Data;
using MiniORM.App.Data.Entities;

namespace MiniORM.App;

public class StartUp
{
    static void Main(string[] args)
    {
        SoftUniDbContext dbContext = new SoftUniDbContext(Config.ConnectionString);

        Employee newEmployee = dbContext
            .Employees.First(e => e.FirstName == "Sophia");
        dbContext.Employees.Remove(newEmployee);

        dbContext.SaveChanges();
    }
}