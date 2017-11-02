namespace _9.ListOfPredicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var range = int.Parse(Console.ReadLine());
            var dividers = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Distinct()
                .ToList();


            Func<int, int, bool> filter = (n, d) => n % d == 0;
            var resultListNumber = new List<int>();
            for (int i = 1; i <= range; i++)
            {
                var hasPass = true;
                foreach (var d in dividers)
                {
                    if (!filter(i, d))
                    {
                        hasPass = false;
                    }
                }

                if (hasPass)
                {
                    resultListNumber.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", resultListNumber));
        }
    }
}
