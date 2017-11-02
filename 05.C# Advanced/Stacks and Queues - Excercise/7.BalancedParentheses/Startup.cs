namespace _7.BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if(input[i] == '{' || input[i] == '(' || input[i] == '[')
                {
                    stack.Push(input[i]);
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                    switch (input[i])
                    {
                        case '}':
                            if (stack.Peek() == '{')
                            {
                                stack.Pop();
                            }
                            break;
                        case ']':
                            if (stack.Peek() == '[')
                            {
                                stack.Pop();
                            }
                            break;
                        case ')':
                            if(stack.Peek() == '(')
                            {
                                stack.Pop();
                            }
                            break;
                    }
                }
            }

            if(stack.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
