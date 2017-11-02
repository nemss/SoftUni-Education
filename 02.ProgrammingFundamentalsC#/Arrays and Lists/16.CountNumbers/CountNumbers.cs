using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.CountNumbers
{
    class CountNumbers
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var count =new int[numbers.Max() + 1];

            foreach (var n in numbers)
            {
                count[n]++;
            }
            for (int i = 0; i < count.Length; i++)
            {
                if (count[i]>0)
                {
                    Console.WriteLine($"{i} -> {count[i]}");
                }

            }
            }
        }
    }

