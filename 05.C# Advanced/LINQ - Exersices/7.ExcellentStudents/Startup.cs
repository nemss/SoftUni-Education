namespace _7.ExcellentStudents
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

            //students.Select(s =>
            //{
            //    var tokens = s.Split();
            //    var FirstName = tokens[0];
            //    var LastName = tokens[1];
            //    var Marks = tokens[2];
            //    return new {FirstName, LastName, Marks};
            //})
            //.Where(m => m.Marks.IndexOf("6") >= 0)
            //.ToList()
            //.ForEach(c => Console.WriteLine($"{c.FirstName} {c.LastName}"));

            students.Select(x => x.Split()).Where(x => x.Contains("6")).ToList()
                .ForEach(c => Console.WriteLine($"{c[0]} {c[1]}"));
        }
    }
}
