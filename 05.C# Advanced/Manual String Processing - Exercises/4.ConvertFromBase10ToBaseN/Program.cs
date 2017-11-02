namespace _4.ConvertFromBase10ToBaseN
{
    using System;
    using System.Linq;
    using System.Numerics;

    public class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            
            var baseN = int.Parse(input[0]);
            var number = BigInteger.Parse(input[1]);

            if (baseN >= 2 && baseN <= 10)
            {
                string result = string.Empty;
                while (number > 0)
                {
                    result += Convert.ToString(number % baseN);
                    number /= baseN;
                }

                Console.WriteLine(result.Reverse().ToArray());
            }


        }
    }
}
