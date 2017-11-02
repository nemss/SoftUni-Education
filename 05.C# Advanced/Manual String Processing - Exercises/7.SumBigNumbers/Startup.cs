namespace _7.SumBigNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var firstNumber = new Stack<char>(Console.ReadLine());
            var secondNumber = new Stack<char>(Console.ReadLine());
            var result = new StringBuilder();

            var sum = 0;
            while (firstNumber.Count != 0 || secondNumber.Count != 0)
            {
                 sum = sum / 10;
                if (firstNumber.Count != 0) sum += int.Parse(firstNumber.Pop().ToString());
                if (secondNumber.Count != 0) sum += (int)char.GetNumericValue(secondNumber.Pop());

                
                result.Insert(0, sum % 10);
            }

                result.Insert(0, sum / 10);
    
            Console.WriteLine(result.ToString().TrimStart('0'));
        }
    }
}
