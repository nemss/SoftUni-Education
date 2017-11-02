namespace _5.BorderControl
{
    using _5.BorderControl.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        private static void Main(string[] args)
        {
            List<ISociety> societies = new List<ISociety>();

            string inputLine;
            while (!(inputLine = Console.ReadLine()).Equals("End"))
            {
                var tokens = inputLine.Split(' ');

                if (tokens.Length == 2)
                {
                    var robot = new Robot(tokens[0], tokens[1]);
                    societies.Add(robot);
                }
                else if (tokens.Length == 3)
                {
                    var person = new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2]);
                    societies.Add(person);
                }
            }

            var checkId = Console.ReadLine();

            societies.Where(p => p.Id.EndsWith(checkId))
                .ToList()
                .ForEach(c => Console.WriteLine(c.Id));
        }
    }
}