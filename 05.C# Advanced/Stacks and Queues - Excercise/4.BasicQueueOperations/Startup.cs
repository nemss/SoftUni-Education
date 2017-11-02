namespace _4.BasicQueueOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').ToArray();
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>(numbers);

            int enqueue = int.Parse(input[0]);
            int dequeue = int.Parse(input[1]);
            int containsInStack = int.Parse(input[2]);
            if (queue.Count <= dequeue)
            {
                Console.WriteLine("0");
            }
            else
            {
                for (int i = 0; i < dequeue; i++)
                {
                    queue.Dequeue();
                }

                if (queue.Contains(containsInStack))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine($"{queue.Min()}");
                }
            }
        }
    }
}
