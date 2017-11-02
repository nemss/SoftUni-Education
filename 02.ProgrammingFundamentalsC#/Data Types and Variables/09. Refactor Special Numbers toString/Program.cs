using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Refactor_Special_Numbers_toString
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <=n; i++)
            {
                int sumOfDigits = 0;
                string number = i.ToString();

                for (int j = 0; j < number.Length; j++)
                {
                    sumOfDigits += int.Parse(number[j].ToString());
                }

                bool result = (sumOfDigits == 5 || sumOfDigits == 7 || sumOfDigits == 11);
                Console.WriteLine($"{i} -> {result}");
            }
        }
    }
}
