namespace _10.GroupByGroup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var students = new List<string>();

            while (!input.Equals("END"))
            {
                students.Add(input);

                input = Console.ReadLine();
            }

            students.Select(s =>
            {
                var tokens = s.Split(' ');
                var Name = tokens[0] + " " + tokens[1];
                var Group = int.Parse(tokens[2]);
                return new {Name ,Group};
            })
            .GroupBy(s => s.Group, s => s.Name)
            .OrderBy(s => s.Key)
            .ToList()
            .ForEach(c => Console.WriteLine($"{c.Key} - {string.Join(", ", c)}"));

        }
    }
}
