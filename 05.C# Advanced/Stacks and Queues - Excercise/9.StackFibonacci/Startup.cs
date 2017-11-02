namespace _9.StackFibonacci
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main(string[] args)
        {
            int nthNumbers = int.Parse(Console.ReadLine());

            Stack<long> stack = new Stack<long>();

            stack.Push(0);
            stack.Push(1);

            for (int i = 0; i < nthNumbers - 1; i++)
            {
                long first = stack.Peek();
                stack.Pop();
                long second = stack.Pop();
                stack.Push(first);
                stack.Push(first + second);
            }

            Console.WriteLine(stack.Peek());
        }
    }
}
