using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Condense_Array_to_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            while(numbers.Length > 1)
            {
                var result = new int[numbers.Length - 1];

                for (int i = 0; i < numbers.Length - 1; i++)
                {
                    result[i] = numbers[i] + numbers[i + 1];
                }
                numbers = result;
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
