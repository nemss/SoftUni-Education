using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.RemoveNegativesAndReverse
{
    class Program
    { 
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int countNegativeNumber = 0;
            foreach (var n in numbers)
            {
                if(n < 0)
                {
                    countNegativeNumber++;
                }
            }

            if (countNegativeNumber == numbers.Count)
            {
                Console.WriteLine("empty");

            }
            else
            {
                numbers.RemoveAll(i => i < 0);
                numbers.Reverse();
                Console.WriteLine(string.Join(" ", numbers));
            }
        }
    }
}
