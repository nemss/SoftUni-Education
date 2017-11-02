namespace _1.MatrixOfPolindromes
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ');
            var r = int.Parse(input[0]);
            var c = int.Parse(input[1]);
            string[] alphabet =
            {
                "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u",
                "v", "w", "x", "y", "z"
            };

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    Console.Write($"{alphabet[i]}{alphabet[i + j]}{alphabet[i]} ");
                }
                Console.WriteLine();
            }

        }
    }
}
