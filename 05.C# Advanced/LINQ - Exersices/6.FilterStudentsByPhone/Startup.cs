namespace _6.FilterStudentsByPhone
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
                var tokens = s.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var FirstName = tokens[0];
                var LastName = tokens[1];
                var Phone = tokens[2];
                return new {FirstName, LastName, Phone};
            })
            .Where(p => p.Phone.StartsWith("02") || p.Phone.StartsWith("+3592"))
            .ToList()
            .ForEach(c => Console.WriteLine($"{c.FirstName} {c.LastName}"));
        }
    }
}
