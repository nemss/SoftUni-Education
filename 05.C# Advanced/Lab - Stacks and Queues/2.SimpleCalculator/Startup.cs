namespace _2.SimpleCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();
            Stack<string> stack = new Stack<string>(input.Reverse());

            while(stack.Count > 1)
            {
                int firstNumber = int.Parse(stack.Pop());
                char operation = char.Parse(stack.Pop());
                int seconfNumber = int.Parse(stack.Pop());

                if(operation == '+')
                {
                    stack.Push((firstNumber + seconfNumber).ToString());
                }
                else if(operation == '-')
                {
                    stack.Push((firstNumber - seconfNumber).ToString());
                }
            }

            Console.WriteLine(string.Join("", stack));
        }
    }
}
