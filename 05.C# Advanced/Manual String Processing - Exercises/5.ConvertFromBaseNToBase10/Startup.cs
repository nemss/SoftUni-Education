namespace _5.ConvertFromBaseNToBase10
{
    using System;
    using System.Linq;
    using System.Numerics;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var fromBase = int.Parse(input[0]);
            var number = input[1];

            BigInteger bigInteger = 0;

            var power = number.Length - 1;

            for (int i = 0; i < number.Length; i++)
            {
                BigInteger num = BigInteger.Parse(number[i].ToString());
                bigInteger += BigInteger.Multiply(num, BigInteger.Pow(fromBase, power));
                power--;
            }

            Console.WriteLine(bigInteger);
        }
    }
}
