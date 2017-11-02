using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Employee_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName = Console.ReadLine();
            string secondName = Console.ReadLine();
            string age = Console.ReadLine();
            char gender = char.Parse(Console.ReadLine());
            long Id = long.Parse(Console.ReadLine());
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine("First name: {0}",firstName);
            Console.WriteLine("Last name: {0}",secondName);
            Console.WriteLine("Age: {0}",age);
            Console.WriteLine("Gender: {0}",gender);
            Console.WriteLine("Personal ID: {0}",Id);
            Console.WriteLine("Unique Employee number: {0}",number);
        }
    }
}
