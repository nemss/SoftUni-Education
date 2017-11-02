using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using _03BarracksFactory.Attributes;

namespace _03BarracksFactory.Core
{
    using _03BarracksFactory.Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string CommandSuffix = "Command";
        private IRepository repository;
        private IUnitFactory unitFactory;

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            var commandCompleteName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(commandName) + CommandSuffix;

            var commandType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == commandCompleteName);

            object[] commandParams =
            {
                data
            };

            if (commandType == null)
            {
                throw new   InvalidOperationException("Inavid command!");
            }

            var currentCommand = (IExecutable) Activator.CreateInstance(commandType, commandParams);

            currentCommand = this.InjectDependencies(currentCommand);

            return currentCommand;
        }

        private IExecutable InjectDependencies(IExecutable currentCommand)
        {
            var commandFields = currentCommand.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.GetCustomAttributes<InjectAttribute>() != null)
                .ToArray();

            var interpreterFilds = this.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (FieldInfo commandField in commandFields)
            {
                commandField.SetValue(currentCommand, interpreterFilds.First(f => f.FieldType == commandField.FieldType)
                    .GetValue(this));
            }

            return currentCommand;
        }
    }
}
