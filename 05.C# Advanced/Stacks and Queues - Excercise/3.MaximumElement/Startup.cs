namespace _3.MaximumElement
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            Stack<int> maxNumberStack = new Stack<int>();
            int maxNumber = int.MinValue;

            for (int i = 0; i < quantity; i++)
            {
                string[] input = Console.ReadLine().Split(' ');

                string command = input[0];

                if(command == "1")
                {
                    int number = int.Parse(input[1]);
                    if(number > maxNumber)
                    {
                        maxNumber = number;
                        maxNumberStack.Push(number);
                    }
                    stack.Push(number);
                }
                else if(command == "2")
                {
                    int popNumber = stack.Pop();
                    int peekMaxNumber = maxNumberStack.Peek();
                    
                    if(popNumber == peekMaxNumber)
                    {
                        maxNumberStack.Pop();
                        if(maxNumberStack.Count == 0)
                        {
                            maxNumber = int.MinValue;
                        }
                        else
                        {
                            maxNumber = maxNumberStack.Peek();
                        }
                    }
                }
                else if(command == "3")
                {
                    Console.WriteLine($"{maxNumberStack.Peek()}");
                }
            }
        }
    }
}
