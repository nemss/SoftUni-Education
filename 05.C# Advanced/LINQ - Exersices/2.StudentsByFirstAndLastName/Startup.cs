namespace _2.StudentsByFirstAndLastName
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var listStudents = new List<string>();

            while (!input.Equals("END"))
            {
                listStudents.Add(input);

                input = Console.ReadLine();
            }

            listStudents.Select(l =>
            {
                var tokens = l.Split(' ');
                var firstName = tokens[0];
                var lastName = tokens[1];
                return new {firstName, lastName};
            })
            .Where(a => a.firstName.CompareTo(a.lastName) == -1)
            .ToList()
            .ForEach(n => Console.WriteLine($"{n.firstName} {n.lastName}"));
        }
    }
}
