using SoftUni.Data;

namespace SoftUni;

public class StartUp
{
    //01. Import the SoftUni Database into SQL Management Studio 
    //02. Database First (scaffold the database)
    static void Main(string[] args)
    {
        SoftUniContext dbContext = new SoftUniContext();
        Console.WriteLine("Connected!");
    }


}