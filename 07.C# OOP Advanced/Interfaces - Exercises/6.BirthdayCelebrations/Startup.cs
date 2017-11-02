namespace _6.BirthdayCelebrations
{
    using _6.BirthdayCelebrations.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var citizens = new List<IBirthday>();
            string inputLine;
            while (!(inputLine = Console.ReadLine()).Equals("End"))
            {
                var tokens = inputLine.Split(' ');

                if (tokens[0] == "Citizen")
                {
                    citizens.Add(new Citizen(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]));
                }
                else if (tokens[0] == "Pet")
                {
                    citizens.Add(new Pet(tokens[1], tokens[2]));
                }
            }

            var checkDate = Console.ReadLine();

            citizens.Where(x => x.Birthday.EndsWith(checkDate))
                .ToList()
                .ForEach(c => Console.WriteLine(c.Birthday));
        }
    }
}