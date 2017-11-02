namespace _8.MultiplyBigNumber
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var firstNumber = new Stack<char>(Console.ReadLine());
            var secondNumber = Console.ReadLine();
            var result = new StringBuilder();

            var sum = 0;
            while (firstNumber.Count > 0)
            {
                sum = sum / 10;
                sum += (int.Parse(firstNumber.Pop().ToString()) * int.Parse(secondNumber));

                result.Insert(0, sum % 10);

            }

            result.Insert(0, sum / 10);
            if (int.Parse(secondNumber) == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                Console.WriteLine(result.ToString().TrimStart('0'));
            }
        }
    }
}
