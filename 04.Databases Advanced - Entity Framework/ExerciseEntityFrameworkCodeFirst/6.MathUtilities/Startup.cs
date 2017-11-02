namespace _6.MathUtilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class Startup
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            while (!input[0].Equals("End"))
            {
                double firstNumber = double.Parse(input[0]);
                double secondNumber = double.Parse(input[2]);

                switch (input[1])
                {
                    case "+":
                        Console.WriteLine($"{MathUtil.Sum(firstNumber, secondNumber):f2}");
                        break;
                    case "-":
                        Console.WriteLine($"{MathUtil.Subtract(firstNumber, secondNumber):f2}");
                        break;
                    case "/":
                        Console.WriteLine($"{MathUtil.Divide(firstNumber, secondNumber):f2}");
                        break;
                    case "%":
                        Console.WriteLine($"{MathUtil.Percentage(firstNumber, secondNumber):f2}");
                        break;
                    case "*":
                        Console.WriteLine($"{MathUtil.Multiply(firstNumber, secondNumber):f2}");
                        break;
                }

                input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
