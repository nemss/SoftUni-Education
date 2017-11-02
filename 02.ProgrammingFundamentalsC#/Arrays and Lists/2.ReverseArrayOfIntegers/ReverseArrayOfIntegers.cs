using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.ReverseArrayOfIntegers
{
    class ReverseArrayOfIntegers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] numbers = new int[n];

            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }


            for (int i = numbers.Length - 1; i >= 0; i--)
            {

                Console.Write(numbers[i]);
                if (i > 0)
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.WriteLine();
                }
            }

        }
    }
}
