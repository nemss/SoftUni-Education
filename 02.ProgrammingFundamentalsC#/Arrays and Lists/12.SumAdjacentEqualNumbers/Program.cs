using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.SumAdjacentEqualNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ').Select(double.Parse).ToList();
            

            for (int i = 1; i < numbers.Count; i++)
            {
                if(numbers[i-1]==numbers[i])
                {
                    numbers[i - 1] += numbers[i];
                    numbers.RemoveAt(i);
                    i -= 2;
                    if(i < 0)
                    {
                        i = 0;
                    }
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
