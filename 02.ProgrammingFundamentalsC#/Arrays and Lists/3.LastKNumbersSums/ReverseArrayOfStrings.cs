using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseArrayOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = Console.ReadLine().Split(' ').ToArray();
            var stringRevers = number.Reverse();
            Console.WriteLine(string.Join(" ", stringRevers));
            
        }
    }
}
