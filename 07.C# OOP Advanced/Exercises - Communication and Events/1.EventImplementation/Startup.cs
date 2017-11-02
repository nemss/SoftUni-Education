using System;

namespace _1.EventImplementation
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var dispatcher = new Dispatcher();
            var handler = new Handler();

            dispatcher.NameChange += handler.OnDispatcherNameChange;
            var name = string.Empty;
            while (!(name = Console.ReadLine()).Equals("End"))
            {
                dispatcher.Name = name;
            }
        }
    }
}