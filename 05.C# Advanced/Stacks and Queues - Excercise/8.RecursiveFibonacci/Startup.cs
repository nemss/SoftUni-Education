namespace _8.RecursiveFibonacci
{
    using System;

    public class Startup
    {
        private static long[] fibNumbers;
        public static void Main(string[] args)
        {
            int nthNumbers = int.Parse(Console.ReadLine());
            fibNumbers = new long[nthNumbers];
            long result = GetFibonacci(nthNumbers);
            Console.WriteLine(result);
        }

        private static long GetFibonacci(int nthNumbers)
        {
            if(nthNumbers <= 2)
            {
                return 1;
            }
            if(fibNumbers[nthNumbers - 1] != 0)
            {
                return fibNumbers[nthNumbers - 1];
            }

            return fibNumbers[nthNumbers - 1] = GetFibonacci(nthNumbers - 1) + GetFibonacci(nthNumbers - 2);
        }
    }
}
