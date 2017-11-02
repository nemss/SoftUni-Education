namespace _10.SimpleTextEditor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Stack<string> stack = new Stack<string>();
            string text = "";
            stack.Push(text);

            for (int i = 0; i < number; i++)
            {
                string[] arguments = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = arguments[0];
                switch (command)
                {
                    case "1":
                        text += arguments[1];
                        stack.Push(text);
                        break;
                    case "2":
                        int lastCountElements = int.Parse(arguments[1]);

                        text = text.Substring(0, text.Length - lastCountElements);
                        stack.Push(text);
                        break;
                    case "3":
                        int indexForPrint = int.Parse(arguments[1]);
                        Console.WriteLine(text[indexForPrint - 1]);
                        break;
                    case "4":
                        stack.Pop();
                        text = stack.Peek();
                        break;
                }

            }
        }
    }
}
