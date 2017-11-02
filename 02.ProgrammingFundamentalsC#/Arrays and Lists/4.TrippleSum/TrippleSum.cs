using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.TrippleSum
{
    class TrippleSum
    {
        static void Main(string[] args)
        {
            int[] arraysNumber = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            bool isFaund = false;
            for (int i = 0; i < arraysNumber.Length; i++)
            {
                int firstNumber = arraysNumber[i];
                for (int j = i + 1; j < arraysNumber.Length; j++)
                {
                    int secondNumber = arraysNumber[j];

                    int sum = firstNumber + secondNumber;

                    if (arraysNumber.Contains(sum))
                    {
                        Console.WriteLine($"{firstNumber} + {secondNumber} == {sum}");
                        isFaund = true;
                    }
                }
            }
            if(!isFaund)
            {
                Console.WriteLine("No");
            }
        }
    }
}