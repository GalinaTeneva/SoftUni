using System;
using System.Collections.Generic;

namespace _07.CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> employeesByCompany = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] currCompanyEmploeePair = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string currCompanyName = currCompanyEmploeePair[0];
                string currEmployeeId = currCompanyEmploeePair[1];

                if (!employeesByCompany.ContainsKey(currCompanyName))
                {
                    employeesByCompany[currCompanyName] = new List<string>();
                }
                bool isIdUnique = employeesByCompany[currCompanyName].Contains(currEmployeeId);

                if (!isIdUnique)
                {
                    employeesByCompany[currCompanyName].Add(currEmployeeId);
                }

                input = Console.ReadLine();
            }

            foreach (KeyValuePair<string, List<string>> kvp in employeesByCompany)
            {
                Console.WriteLine(kvp.Key);
                foreach (string employeeID in kvp.Value)
                {
                    Console.WriteLine($"-- {employeeID}");
                }
            }
        }
    }
}
