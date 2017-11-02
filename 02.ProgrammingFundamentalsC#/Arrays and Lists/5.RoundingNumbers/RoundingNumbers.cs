using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.RoundingNumbers
{
    class RoundingNumbers
    {
        static void Main(string[] args)
        {
            var number = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            int[] roundingNumbers = new int[number.Length];

            for (int i = 0; i < number.Length; i++)
            {
                roundingNumbers[i] = (int)Math.Round(number[i], MidpointRounding.AwayFromZero);
            }

            for (int i = 0; i < number.Length; i++)
            {
                Console.WriteLine($"{number[i]} -> {roundingNumbers[i]}");
            }

        }
    }
}
