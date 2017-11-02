using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.ExtractMiddleElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            TakeTheElementsInTheMiddle(numbers);
        }

        private static void TakeTheElementsInTheMiddle(int[] numbers)
        {
            if (numbers.Length == 1)
            {
                Console.WriteLine(numbers[0]);
            }
            else if (numbers.Length % 2 == 0)
            {
                int[] a ={ numbers[numbers.Length / 2 - 1], numbers[numbers.Length / 2] };
                Console.WriteLine($"{{ {a[0]}, {a[1]} }}"); 
            }
            else
            {
                int[] a = { numbers[numbers.Length / 2 - 1], numbers[numbers.Length / 2], numbers[numbers.Length / 2 + 1] };
                Console.WriteLine($"{{ {a[0]}, {a[1]}, {a[2]} }}");
            }
        }
    }
}
