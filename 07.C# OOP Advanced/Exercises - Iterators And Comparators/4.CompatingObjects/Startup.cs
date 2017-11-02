namespace _4.CompatingObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var listOfPersons = new List<Person>();
            string inputLine = string.Empty;
            while (!(inputLine = Console.ReadLine()).Equals("END"))
            {
                var tokens = inputLine.Split(' ').ToList();
                var name = tokens[0];
                var age = int.Parse(tokens[1]);
                var town = tokens[2];

                listOfPersons.Add(new Person(name, age, town));
            }

            var index = int.Parse(Console.ReadLine());
            var person = listOfPersons[index - 1];

            var numberOfEquelPeople = listOfPersons.Count(x => x.CompareTo(person) == 0);
            var numberOfNotEquelPeople = listOfPersons.Count(x => x.CompareTo(person) != 0);

            Console.WriteLine(numberOfEquelPeople < 2 ? "No matches" : $"{numberOfEquelPeople} {numberOfNotEquelPeople} {listOfPersons.Count}");
        }
    }
}