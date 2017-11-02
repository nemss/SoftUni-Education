using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionaries__Lambda_and_LINQ
{
    class CountRealNumbers
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(number =>double.Parse(number)).ToArray();
            var count = new SortedDictionary<Double, int>();

            foreach (var num in input)
            {
                
                if (count.ContainsKey(num))
                {
                    count[num]++;
                }
                else
                {
                    count[num] = 1;
                }
            }
                foreach (KeyValuePair<double, int> item in count)
                {
                    Console.WriteLine($"{item.Key} -> {item.Value}");
                }
            }
        }
    }

