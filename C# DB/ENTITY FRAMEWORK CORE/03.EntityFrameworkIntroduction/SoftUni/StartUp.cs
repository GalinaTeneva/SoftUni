using SoftUni.Data;
using SoftUni.Models;
using System.Globalization;
using System.Text;

namespace SoftUni;

public class StartUp
{
    //01. Import the SoftUni Database into SQL Management Studio 
    //02. Database First (scaffold the database)
    static void Main(string[] args)
    {
        SoftUniContext dbContext = new SoftUniContext();

        ////03. Employees Full Information
        //string result1 = GetEmployeesFullInformation(dbContext);
        //Console.WriteLine(result1);

        ////04. Employees with Salary Over 50 000
        //string result2 = GetEmployeesWithSalaryOver50000(dbContext);
        //Console.WriteLine(result2);

        ////05. Employees from Research and Development
        //string result3 = GetEmployeesFromResearchAndDevelopment(dbContext);
        //Console.WriteLine(result3);

        ////06. Adding a New Address and Updating Employee
        //string result4 = GetEmployeesFromResearchAndDevelopment(dbContext);
        //Console.WriteLine(result4);

        ////07. Employees and Projects
        //string result5 = GetEmployeesInPeriod(dbContext);
        //Console.WriteLine(result5);

        ////08. Addresses by Town
        //string result6 = GetAddressesByTown(dbContext);
        //Console.WriteLine(result6);

        ////09. Employee 147
        //string result7 = GetEmployee147(dbContext);
        //Console.WriteLine(result7);

        ////10. Departments with More Than 5 Employees
        //string result8 = GetDepartmentsWithMoreThan5Employees(dbContext);
        //Console.WriteLine(result8);

        ////11. Find Latest 10 Projects
        //string result9 = GetLatestProjects(dbContext);
        //Console.WriteLine(result9);

        //12. Increase Salaries
        string result10 = IncreaseSalaries(dbContext);
        Console.WriteLine(result10);
    }

    //03. Employees Full Information
    public static string GetEmployeesFullInformation(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employees = context.Employees
            .OrderBy(e => e.EmployeeId)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.MiddleName,
                e.JobTitle,
                e.Salary
            })
            .ToArray();

        foreach (var employee in employees)
        {
            sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
        }

        return sb.ToString().TrimEnd();
    }

    //04. Employees with Salary Over 50 000
    public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employees = context.Employees
            .Where(e => e.Salary > 50_000)
            .OrderBy(e => e.FirstName)
            .Select(e => new
            {
                e.FirstName,
                e.Salary
            })
            .ToArray();

        foreach (var employee in employees)
        {
            sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
        }

        return sb.ToString().TrimEnd();
    }

    //05. Employees from Research and Development
    public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employees = context.Employees
            .Where(e => e.Department.Name == "Research and Development")
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                DepartmentName = e.Department.Name,
                e.Salary
            })
            .OrderBy(e => e.Salary)
            .ThenByDescending(e => e.FirstName)
            .ToArray();

        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:F2}");
        }

        return sb.ToString().TrimEnd();
    }

    //06. Adding a New Address and Updating Employee
    public static string AddNewAddressToEmployee(SoftUniContext context)
    {
        Address newAddress = new Address()
        {
            AddressText = "Vitoshka 15",
            TownId = 4
        };

        Employee? employee = context.Employees
            .FirstOrDefault(e => e.LastName == "Nakov");
        employee!.Address = newAddress;

        context.SaveChanges();

        string[] employeeAddress = context.Employees
            .OrderByDescending(e => e.AddressId)
            .Take(10)
            .Select(e => e.Address!.AddressText)
            .ToArray();

        return String.Join(Environment.NewLine, employeeAddress);
    }

    //07. Employees and Projects
    public static string GetEmployeesInPeriod(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();
        var employeesWithProjects = context.Employees
            .Take(10)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                ManagerFirstName = e.Manager!.FirstName,
                ManagerLastName = e.Manager!.LastName,
                Projects = e.EmployeesProjects
                    .Where(ep => ep.Project.StartDate.Year >= 2001 &&
                                 ep.Project.StartDate.Year <= 2003)
                    .Select(ep => new
                    {
                        ProjectName = ep.Project.Name,
                        StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                        EndDate = ep.Project.EndDate.HasValue
                            ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                            : "not finished"
                    })
                    .ToArray()
            })
            .ToArray();

        foreach (var e in employeesWithProjects)
        {
            sb
                .AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");

            foreach (var p in e.Projects)
            {
                sb
                    .AppendLine($"--{p.ProjectName} - {p.StartDate} - {p.EndDate}");
            }
        }

        return sb.ToString().TrimEnd();
    }

    //08. Addresses by Town
    public static string GetAddressesByTown(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var addresses = context.Addresses
            .Select(a => new
            {
                a.AddressText,
                TownName = a.Town!.Name,
                EmployeeCount = a.Employees.Count
            })
            .OrderByDescending(a => a.EmployeeCount)
            .ThenBy(a => a.TownName)
            .ThenBy(a => a.AddressText)
            .Take(10)
            .ToArray();

        foreach (var a in addresses)
        {
            sb.AppendLine($"{a.AddressText}, {a.TownName} - {a.EmployeeCount} employees");
        }

        return sb.ToString().TrimEnd();
    }

    //09. Employee 147
    public static string GetEmployee147(SoftUniContext context)
    {
        var employees = context.Employees
            .Where(e => e.EmployeeId == 147)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.JobTitle,
                Projects = e.EmployeesProjects
                    .Select(ep => new
                    {
                        ProjectName = ep.Project.Name
                    })
                    .OrderBy(ep => ep.ProjectName)
                    .ToArray()
            })
            .ToArray();

        StringBuilder sb = new StringBuilder();

        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");

            foreach (var ep in e.Projects)
            {
                sb.AppendLine($"{ep.ProjectName}");
            }
        }

        return sb.ToString().TrimEnd();
    }

    //10. Departments with More Than 5 Employees
    public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var departments = context.Departments
            .Where(d => d.Employees.Count > 5)
            .OrderBy(d => d.Employees.Count)
            .ThenBy(d => d.Name)
            .Select(d => new
            {
                DepartmentName = d.Name,
                ManagerFirstName = d.Manager.FirstName,
                ManagerLastName = d.Manager.LastName,
                Employees = d.Employees
                    .Select(e => new
                    {
                        EmployeeFirstName = e.FirstName,
                        EmployeeLastName = e.LastName,
                        EmployeeJobTitle = e.JobTitle
                    })
                    .OrderBy(e => e.EmployeeFirstName)
                    .ThenBy(e => e.EmployeeLastName)
                    .ToArray()
            })
            .ToArray();

        foreach (var d in departments)
        {
            sb.AppendLine($"{d.DepartmentName} – {d.ManagerFirstName} {d.ManagerLastName}");

            foreach (var e in d.Employees)
            {
                sb.AppendLine($"{e.EmployeeFirstName} {e.EmployeeLastName} - {e.EmployeeJobTitle}");
            }
        }

        return sb.ToString().TrimEnd();
    }

    //11. Find Latest 10 Projects
    public static string GetLatestProjects(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var projects = context.Projects
            .OrderByDescending(p => p.StartDate)
            .Take(10)
            .OrderBy(p => p.Name)
            .Select(p => new
            {
                p.Name,
                p.Description,
                StartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
            })
            .ToArray();

        foreach (var p in projects)
        {
            sb.AppendLine($"{p.Name}");
            sb.AppendLine($"{p.Description}");
            sb.AppendLine($"{p.StartDate}");
        }

        return sb.ToString().TrimEnd();
    }

    //12. Increase Salaries
    public static string IncreaseSalaries(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        decimal increaseInPercent = 0.12m;

        Employee[] employees = context.Employees
            .Where(e => e.Department.Name == "Engineering" || e.Department.Name == "Tool Design" ||
                        e.Department.Name == "Marketing" || e.Department.Name == "Information Services")
            .ToArray();

        foreach (Employee e in employees)
        {
            e.Salary += e.Salary * increaseInPercent;
        }

        context.SaveChanges();

        var employeesWithUpdatedSalaries = context.Employees
            .Where(e => e.Department.Name == "Engineering" || e.Department.Name == "Tool Design" ||
                        e.Department.Name == "Marketing" || e.Department.Name == "Information Services")
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.Salary
            })
            .OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName)
            .ToArray();

        foreach (var e in employeesWithUpdatedSalaries)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:F2})");
        }

        return sb.ToString().TrimEnd();
    }
}