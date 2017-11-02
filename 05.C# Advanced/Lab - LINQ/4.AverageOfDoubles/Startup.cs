using System.Linq;

namespace _4.AverageOfDoubles
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ' )
                .Select(double.Parse)
                .Average();

            Console.WriteLine($"{input:f2}");

       
        }
    }
}
