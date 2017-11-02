namespace Library.Client
{
    using Core;
    using Data;
    using System;
    using static System.Net.Mime.MediaTypeNames;

    class Startup
    {
        static void Main(string[] args)
        {
            LibraryContext context = new LibraryContext();
            //context.Database.Initialize(true);

            Console.WindowHeight = 20;
            Console.WindowWidth = 84;
           
            Console.WriteLine($"{"Welcome to our book library", 55}");
            Console.WriteLine("Press Enter to start");
            var key = Console.ReadKey();
           
            switch(key.Key.ToString())
            {
                case "Enter":
                    Console.Clear();
                    while (true)
                    {
                        Engine engine = new Engine(new CommandDispatcher());
                        engine.Run();
                    }
                case "Escape":
                    Environment.Exit(0);
                    break;
            }
           
        }
    }
}
