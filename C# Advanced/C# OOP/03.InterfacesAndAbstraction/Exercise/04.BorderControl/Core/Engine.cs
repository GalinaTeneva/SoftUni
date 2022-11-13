
namespace BorderControl.Core
{
    using BorderControl.Core.Interfaces;
    using BorderControl.Models;
    using BorderControl.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine : IEngine
    {
        private readonly ICollection<IVisitor> visitors;

        public Engine()
        {
            this.visitors = new HashSet<IVisitor>();
        }

        public void Run()
        {
            string cmd = Console.ReadLine();
            while (cmd != "End")
            {
                string[] cmdTokens = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                IVisitor visitor = null;
                if (cmdTokens.Length == 3)
                {
                    visitor = GenerateCitizen(cmdTokens);
                }
                else if (cmdTokens.Length == 2)
                {
                    visitor = GenerateRobot(cmdTokens);
                }

                visitors.Add(visitor);

                cmd = Console.ReadLine();
            }

            string fakeIdDigits = Console.ReadLine();

            Console.WriteLine(string.Join(Environment.NewLine, visitors.Where(v => v.Id.EndsWith(fakeIdDigits))));
        }

        private IVisitor GenerateCitizen(string[] cmdTokens)
        {
            string id = cmdTokens[2];
            string name = cmdTokens[0];
            int age = int.Parse(cmdTokens[1]);

            return new Citizen(id, name, age);
        }

        private IVisitor GenerateRobot(string[] cmdTokens)
        {
            string id = cmdTokens[1];
            string model = cmdTokens[0];

            return new Robot(id, model);
        }
    }
}
