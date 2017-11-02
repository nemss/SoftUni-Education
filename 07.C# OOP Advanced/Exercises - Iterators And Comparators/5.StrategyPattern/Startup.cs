using _5.StrategyPattern.Models;
using System;
using System.Collections.Generic;

namespace _5.StrategyPattern
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var numberOfLines = int.Parse(Console.ReadLine());
            SortedSet<Person> firstList = new SortedSet<Person>(new PersonCompareByName());
            SortedSet<Person> secondList = new SortedSet<Person>(new PersonCampareByAge());

            for (int i = 0; i < numberOfLines; i++)
            {
                var inputLine = Console.ReadLine().Split(' ');
                var name = inputLine[0];
                var age = int.Parse(inputLine[1]);

                firstList.Add(new Person(name, age));
                secondList.Add(new Person(name, age));
            }

            Console.WriteLine(string.Join(Environment.NewLine, firstList));
            Console.WriteLine(string.Join(Environment.NewLine, secondList));
        }
    }
}