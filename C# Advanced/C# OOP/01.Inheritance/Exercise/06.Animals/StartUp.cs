using System;
using System.Text;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            while (true)
            {
                string animalType = Console.ReadLine();

                if (animalType == "Beast!")
                {
                    break;
                }

                try
                {
                    string[] animalInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string name = animalInfo[0];
                    int age = int.Parse(animalInfo[1]);
                    string gender = string.Empty;

                    if (animalInfo.Length > 2)
                    {
                        gender = animalInfo[2];
                    }

                    if (animalType == "Cat")
                    {
                        Cat cat = new Cat(name, age, gender);
                        sb.AppendLine(cat.ToString());
                    }
                    else if (animalType == "Dog")
                    {
                        Dog dog = new Dog(name, age, gender);
                        sb.AppendLine(dog.ToString());
                    }
                    else if (animalType == "Frog")
                    {
                        Frog frog = new Frog(name, age, gender);
                        sb.AppendLine(frog.ToString());
                    }
                    else if (animalType == "Kitten")
                    {
                        Kitten kitten = new Kitten(name, age);
                        sb.AppendLine(kitten.ToString());
                    }
                    else if (animalType == "Dog")
                    {
                        Tomcat tomcat = new Tomcat(name, age);
                        sb.AppendLine(tomcat.ToString());
                    }
                    else
                    {
                        throw new ArgumentException("Invalid input!");
                    }
                }
                catch(ArgumentException message)
                {
                    Console.WriteLine(message);
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
