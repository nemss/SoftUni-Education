namespace Library.Client.Core.Commands
{
    using System;
    public class ClearCommand
    {
        public string Execute(string[] inputArgs) 
        {
            Console.Clear();
            return $"Successfullu Clear All Text From Console";
        }
    }
}
