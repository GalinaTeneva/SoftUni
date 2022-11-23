
namespace CommandPattern.Utilities
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;


    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] commandArgs = args.Split(' ');
            string commandName = commandArgs[0];
            string[] invokeArgs = commandArgs.Skip(1).ToArray();

            Assembly assembly = Assembly.GetEntryAssembly();
            Type intendedCommandType = assembly.GetTypes().FirstOrDefault(t => t.Name == $"{commandName}Command");

            if (intendedCommandType == null)
            {
                throw new InvalidOperationException("Invalid command type!");
            }

            MethodInfo executeMethodInfo = intendedCommandType
                .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .FirstOrDefault(m => m.Name == "Execute");

            if (executeMethodInfo == null)
            {
                throw new InvalidOperationException("Command doesn not implement required pattern! Try implementing ICommand interface instead!");
            }

            object commandInstance = Activator.CreateInstance(intendedCommandType);
            string result = (string)executeMethodInfo.Invoke(commandInstance, new object[] { invokeArgs});

            return result;
        }
    }
}
