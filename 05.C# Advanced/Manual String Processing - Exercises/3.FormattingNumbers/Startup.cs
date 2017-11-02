namespace _3.FormattingNumbers
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new[] {' ', '\t', '\n', '\r'}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var numberA = int.Parse(input[0]);
            var numberB = double.Parse(input[1]);
            var numberC = double.Parse(input[2]);

            string hex = numberA.ToString("X");
            string binary = Convert.ToString(Convert.ToInt32(hex, 16), 2);

            if (binary.Length < 10)
            {
                binary = binary.PadLeft(10, '0');
            }

            Console.WriteLine($"|{hex, -10}|{binary.Substring(0, 10), 10}|{numberB, 10:f2}|{numberC, -10:f3}|");



        }
    }
}
