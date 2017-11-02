using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.SquareNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> squareNumbers = new List<int>();
            foreach (var num in numbers)
            {
                if(Math.Sqrt(num) == (int)Math.Sqrt(num))
                {
                    squareNumbers.Add(num);
                }
            }

            Console.WriteLine(string.Join(" ", squareNumbers));
        }
    }
}
