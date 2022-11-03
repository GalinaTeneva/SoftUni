using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ShoppingSpree
{
    public class StartUp
    {
        static void Main()
        {
            List<Person> peopleList = new List<Person>();
            List<Product> productsList = new List<Product>();

            try
            {
                string[] peopleInfo = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

                foreach (string item in peopleInfo)
                {
                    string[] personInfo = item.Split('=', StringSplitOptions.RemoveEmptyEntries);
                    Person person = new Person(personInfo[0], decimal.Parse(personInfo[1]));
                    peopleList.Add(person);
                }

                string[] productsInfo = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in productsInfo)
                {
                    string[] productInfo = item.Split('=', StringSplitOptions.RemoveEmptyEntries);
                    Product product = new Product(productInfo[0], decimal.Parse(productInfo[1]));
                    productsList.Add(product);
                }

                while (true)
                {
                    string command = Console.ReadLine();

                    if (command == "END")
                    {
                        break;
                    }

                    string[] lineInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string personName = lineInfo[0];
                    string productName = lineInfo[1];

                    Person person = peopleList.FirstOrDefault(p => p.Name == personName);
                    Product product = productsList.FirstOrDefault(p => p.Name == productName);

                    person.BuyProduct(product);
                }

                foreach (Person person in peopleList)
                {
                    if (person.Bag.Count != 0)
                    {
                        Console.WriteLine($"{person.Name} - {string.Join(", ", person.Bag)}");
                    }
                    else
                    {
                        Console.WriteLine($"{person.Name} - Nothing bought");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
