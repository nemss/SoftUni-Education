namespace _3.DependencyInversion
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var calc = new PrimitiveCalculator();

            var input = Console.ReadLine().Split();
            while (input[0] != "End")
            {
                if (input[0] == "mode")
                {
                    calc.ChangeStrategy(char.Parse(input[1]));
                }
                else
                {
                    Console.WriteLine(calc.PerformCalculation(int.Parse(input[0]), int.Parse(input[1])));
                }

                input = Console.ReadLine().Split();
            }
        }
    }
}