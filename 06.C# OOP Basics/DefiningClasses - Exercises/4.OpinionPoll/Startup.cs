namespace _4.OpinionPoll
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var listOfPerson = new List<Person>();
            var numbersOfPersons = int.Parse(Console.ReadLine());
            for (int i = 0; i < numbersOfPersons; i++)
            {
                var tokens = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var name = tokens[0];
                var age = int.Parse(tokens[1]);
                var person = new Person(name, age);
                listOfPerson.Add(person);
            }

             listOfPerson.Where(x => x.Age > 30)
                .OrderBy(x => x.Name)
                .ToList()
                .ForEach(c => Console.WriteLine($"{c.Name} - {c.Age}"));
        }

    }
}
