namespace _1.StudentsByGroup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var information = new List<string>();

            while (!input.Equals("END"))
            {
                information.Add(input);

                input = Console.ReadLine();
            }

            information.Select(a =>
                {
                    var arguments = a.Split(' ');
                    var firstName = arguments[0];
                    var lastName = arguments[1];
                    var groupNumber = int.Parse(arguments[2]);
                    return new {firstName, lastName, groupNumber};

                })
                .Where(a => a.groupNumber == 2)
                .OrderBy(a => a.firstName)
                .ToList()
                .ForEach(n => Console.WriteLine($"{n.firstName} {n.lastName}"));
        }
    }
}
