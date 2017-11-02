namespace _01.EvenNumbersThread
{
    using System;
    using System.Linq;
    using System.Threading;

    public class Startup
    {
        public static void Main()
        {
            var start = int.Parse(Console.ReadLine());
            var end = int.Parse(Console.ReadLine());

            var thread = new Thread(() => PrintEvenNumber(start, end));
            thread.Start();
            thread.Join();

            Console.WriteLine("Thread finished work");
        }

        private static void PrintEvenNumber(int start, int end)
        {
            var numbers = Enumerable.Range(start, end)
                .Where(n => n % 2 == 0)
                .ToList();

            numbers.ForEach(Console.WriteLine);
        }
    }
}