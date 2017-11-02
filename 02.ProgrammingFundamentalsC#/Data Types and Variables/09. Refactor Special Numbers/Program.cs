using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <=n; i++)
            {
                int sumOfDigits = 0;
                int number = i;

                while(number>0)
                {
                    sumOfDigits += number % 10;
                    number /= 10;
                }

                bool result = (sumOfDigits == 5 || sumOfDigits == 7 || sumOfDigits == 11);
                Console.WriteLine("{0} -> {1}",i,result);
            }
        }
    }
}
