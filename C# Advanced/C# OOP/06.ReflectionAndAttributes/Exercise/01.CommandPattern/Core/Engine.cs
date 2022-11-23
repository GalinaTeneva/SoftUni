
namespace CommandPattern.Core
{
    using System;

    using Utilities.Contracts;
    using Contracts;
    using IO;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly ICommandInterpreter commandInterpreter;

        private Engine()
        {
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();
        }

        public Engine(ICommandInterpreter commandInterpreter)
            : this()
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = this.reader.ReadLine();
                    string result = this.commandInterpreter.Read(input);
                    this.writer.WriteLine(result);
                }
                catch (InvalidOperationException ioe)
                {
                    this.writer.WriteLine(ioe.Message);
                }

            }
        }
    }
}
