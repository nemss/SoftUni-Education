using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Exchange_Variable_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int seconfNumber = int.Parse(Console.ReadLine());

            Console.WriteLine($"Before: \na = {firstNumber}\nb = {seconfNumber}");

            int oldNumber = firstNumber;
            firstNumber = seconfNumber;
            seconfNumber = oldNumber;

            Console.WriteLine($"After: \na = {firstNumber}\nb = {seconfNumber}");
        }
    }
}
