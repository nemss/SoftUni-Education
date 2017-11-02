namespace _2.BasicStackOperations
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                        .Trim()
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

             var numbers = Console.ReadLine()
                           .Split(' ')
                           .Select(int.Parse)
                           .ToArray();

            Stack<int> stack = new Stack<int>(numbers);

            int quantity = int.Parse(input[0]);
            int popQuantity = int.Parse(input[1]);
            int containsInStack = int.Parse(input[2]);

            if (!(stack.Count <= popQuantity))
            {
                for (int i = 0; i < popQuantity; i++)
                {
                    stack.Pop();
                }

                if (stack.Contains(containsInStack))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine($"{stack.Min()}");
                }
            }
            else
            {
                Console.WriteLine("0");
            }
        }
    }
}
