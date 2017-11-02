namespace _4.Telephony
{
    using _4.Telephony.Models;
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var telephones = Console.ReadLine().Split(' ').ToList();
            var links = Console.ReadLine().Split(' ').ToList();

            var smartphone = new Smartphone();

            Console.WriteLine(smartphone.Call(telephones));
            Console.WriteLine(smartphone.BrowseInTheInterner(links));
        }
    }
}