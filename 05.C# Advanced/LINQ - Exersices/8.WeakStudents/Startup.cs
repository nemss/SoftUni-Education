namespace _8.WeakStudents
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

            students.Where(m => m.Skip(2).Count(mark => int.Parse(mark) <= 3) >= 2)
                .ToList()
                .ForEach(c => Console.WriteLine($"{c[0]} {c[1]}"));
        }
    }
}
