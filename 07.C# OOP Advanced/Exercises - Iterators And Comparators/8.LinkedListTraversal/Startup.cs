namespace _8.LinkedListTraversal
{
    using _8.LinkedListTraversal.Models;
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            LinkedList<int> linkedList = new LinkedList<int>();
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var inputLine = Console.ReadLine().Split(' ');

                switch (inputLine[0])
                {
                    case "Add":
                        linkedList.Add(int.Parse(inputLine[1]));
                        break;

                    case "Remove":
                        linkedList.Remove(int.Parse(inputLine[1]));
                        break;
                }
            }

            Console.WriteLine(linkedList.Count);
            Console.WriteLine(string.Join(" ", linkedList));
        }
    }
}