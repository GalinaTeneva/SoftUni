using System;

namespace _05.Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int facebookFine = 150;
            int instagramFine = 100;
            int redditFine = 50;

            int openTabs = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());

            for (int i = 0; i < openTabs && salary != 0; i++)
            {
                string websiteName = Console.ReadLine();

                if (websiteName == "Facebook")
                {
                    salary -= facebookFine;
                }
                if (websiteName == "Instagram")
                {
                    salary -= instagramFine;
                }
                if (websiteName == "Reddit")
                {
                    salary -= redditFine;
                }
                if (salary == 0)
                {
                    Console.WriteLine("You have lost your salary.");
                }
            }

            if (salary > 0)
            {
                Console.WriteLine(salary);
            }
        }
    }
}
