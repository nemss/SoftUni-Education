namespace _4.FindEvensOrOdds
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var evenOrOdd = Console.ReadLine();

            Predicate<int> checkEvenNumber = x => x % 2 == 0;

            for (int i = input[0]; i <= input[1]; i++)
            {
                if (checkEvenNumber.Invoke(i) && evenOrOdd == "even")
                {
                    Console.Write($"{i} ");
                }
                else if ((!checkEvenNumber.Invoke(i)) && evenOrOdd == "odd")
                {
                    Console.Write($"{i }");
                }
            }
        }
    }
}
