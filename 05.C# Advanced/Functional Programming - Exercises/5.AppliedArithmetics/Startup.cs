namespace _5.AppliedArithmetics
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var listNumbers = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Action<List<int>> printNumbers = p => Console.WriteLine(string.Join(" ", p));

            var command = Console.ReadLine();
            while (!command.Equals("end"))
            {

                switch (command)
                {
                    case "add":
                        listNumbers = Operation(listNumbers, n => n.Select(x => x + 1).ToList());
                        break;
                    case "subtract":
                        listNumbers = Operation(listNumbers, n => n.Select(x => x -1).ToList());
                        break;
                    case "multiply":
                        listNumbers = Operation(listNumbers, n => n.Select(x => x * 2).ToList());
                        break;
                    case "print":
                        printNumbers(listNumbers);
                        break;
                }

                command = Console.ReadLine();
            }
        }

        private static List<int> Operation(List<int> numbers, Func<List<int>, List<int>> operation)
        {
            return operation(numbers);
        }

    }
}
