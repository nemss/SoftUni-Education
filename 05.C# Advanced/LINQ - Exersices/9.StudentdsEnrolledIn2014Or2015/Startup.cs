namespace _9.StudentdsEnrolledIn2014Or2015
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var students = new List<string[]>();

            while (!input.Equals("END"))
            {
                students.Add(input.Split(' '));

                input = Console.ReadLine();
            }

            students.Where(m => m[0].EndsWith("14") || m[0].EndsWith("15"))
                .ToList()
                .ForEach(c => Console.WriteLine($"{string.Join(" ", c.Skip(1))}"));
        }
    }
}
