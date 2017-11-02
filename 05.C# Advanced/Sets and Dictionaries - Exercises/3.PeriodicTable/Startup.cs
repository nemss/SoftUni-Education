namespace _3.PeriodicTable
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string> hashSet = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split();

                foreach (var chemical in input)
                {
                    hashSet.Add(chemical);
                }
            }

            Console.WriteLine($"{string.Join(" ", hashSet)}");
            
        }
    }
}
