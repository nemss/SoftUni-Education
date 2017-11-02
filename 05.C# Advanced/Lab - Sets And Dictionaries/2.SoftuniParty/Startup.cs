namespace _2.SoftuniParty
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();

            SortedSet<string> guesList = new SortedSet<string>();

            while(!input.Equals("PARTY"))
            {             
                guesList.Add(input);
                input = Console.ReadLine();
            }

            while(!input.Equals("END"))
            {
                guesList.Remove(input);
                input = Console.ReadLine();
            }
            
            Console.WriteLine($"{(guesList.Count)}");
            foreach (var gues in guesList)
            {
                Console.WriteLine(gues);
            }
        }
    }
}
