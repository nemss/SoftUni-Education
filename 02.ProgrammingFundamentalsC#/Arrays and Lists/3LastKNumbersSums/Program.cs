using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3LastKNumbersSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            long[] array = new long[n];
            array[0] = 1;

            for (int i = 1; i < array.Length; i++)
            {
                long sum = 0;
                int count = k;
                for (int j = i-1; j >=0; j--)
                {
                    if(count == 0)
                    {
                        break;
                    }
                    sum += array[j];
                    count--;
                }
                array[i] = sum;
            }
            Console.WriteLine(string.Join(" ",array));
        }
    }
}
