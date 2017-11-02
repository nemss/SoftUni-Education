namespace _1.ReverseNumberWithStack
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<string> stack = new Stack<string>(input.Split(' '));

            Console.WriteLine(string.Join(" ", stack));
        }
    }
}
