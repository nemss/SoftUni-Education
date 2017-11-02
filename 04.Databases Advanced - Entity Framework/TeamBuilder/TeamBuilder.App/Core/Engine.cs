namespace TeamBuilder.App.Core
{
    using System;
    public class Engine
    {
        private CommandDispatcher commandDispacher;

        public Engine(CommandDispatcher commandDispacher)
        {
            this.commandDispacher = commandDispacher;
        }
        public void Run()
        {
            while(true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string output = this.commandDispacher.Dispatch(input);
                    Console.WriteLine(output);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.GetBaseException().Message);
                }
            }
        }
    }
}
