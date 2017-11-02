namespace _2.Stack.Core
{
    using _2.Stack.Models;
    using System;
    using System.Linq;

    public class Engine
    {
        private Stack<string> myStack;

        public Engine()
        {
            this.myStack = new Stack<string>();
        }

        public void Run()
        {
            bool isRunning = true;
            bool error = false;

            while (isRunning)
            {
                var inputLine = Console.ReadLine()
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                var command = inputLine[0];
                inputLine = inputLine.Skip(1).ToList();

                switch (command)
                {
                    case "Pop":
                        try
                        {
                            myStack.Pop();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            error = true;
                        }
                        break;

                    case "Push":
                        myStack.Push(inputLine);
                        break;

                    case "END":
                        isRunning = false;
                        if (!error)
                        {
                            Console.WriteLine(myStack.PrintAllElements());
                            Console.WriteLine(myStack.PrintAllElements());
                        }
                        break;
                }
            }
        }
    }
}