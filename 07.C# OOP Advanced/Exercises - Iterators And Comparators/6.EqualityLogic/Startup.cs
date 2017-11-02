namespace _6.EqualityLogic
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var numbersOfLines = int.Parse(Console.ReadLine());
            SortedSet<Person> sortedSet = new SortedSet<Person>();
            HashSet<Person> hashSet = new HashSet<Person>();

            for (int i = 0; i < numbersOfLines; i++)
            {
                var inputLine = Console.ReadLine().Split(' ');
                var name = inputLine[0];
                var age = int.Parse(inputLine[1]);

                sortedSet.Add(new Person(name, age));
                hashSet.Add(new Person(name, age));
            }

            Console.WriteLine(sortedSet.Count);
            Console.WriteLine(hashSet.Count);
        }
    }
}