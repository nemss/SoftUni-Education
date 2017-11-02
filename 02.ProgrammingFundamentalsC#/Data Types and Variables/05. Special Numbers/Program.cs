using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                int sumOfDgits = 0;
                int number = i;

                while(number>0)
                {
                    sumOfDgits += number % 10;
                    number /= 10;
                }
                bool result = (sumOfDgits == 5 || sumOfDgits == 7 || sumOfDgits == 11);
                Console.WriteLine("{0} -> {1}",i,result);
            }
        }
    }
}
