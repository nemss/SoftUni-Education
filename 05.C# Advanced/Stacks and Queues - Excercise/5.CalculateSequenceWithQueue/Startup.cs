namespace _5.CalculateSequenceWithQueue
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());
            Queue<long> queue = new Queue<long>();

            queue.Enqueue(number);

            for (int i = 0; i < 50; i++)
            {
                long currentElement = queue.Dequeue();
                Console.Write(currentElement + " ");
                queue.Enqueue(currentElement + 1);
                queue.Enqueue(currentElement * 2 + 1);
                queue.Enqueue(currentElement + 2);
            }

            
        }
    }
}
