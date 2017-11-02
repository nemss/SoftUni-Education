namespace Library.Client.Core.Commands
{
    using System;
    using Utilities;

    public class ExitCommand
    {
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(0, inputArgs);
            Environment.Exit(0);
            return "Bye!";
        }
    }
}
