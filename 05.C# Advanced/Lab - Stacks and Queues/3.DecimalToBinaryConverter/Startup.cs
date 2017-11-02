namespace _3.DecimalToBinaryConverter
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            if(input == 0)
            {
                Console.WriteLine("0");
            }
            else if(input > 0)
            {
                while (input != 0)
                {
                    stack.Push(input % 2);
                    input /= 2;
                }
                Console.WriteLine(string.Join("", stack));
            }
        }
    }
}

