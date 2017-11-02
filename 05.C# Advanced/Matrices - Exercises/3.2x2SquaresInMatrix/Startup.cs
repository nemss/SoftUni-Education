namespace _3._2x2SquaresInMatrix
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            var r = int.Parse(input[0]);
            var c = int.Parse(input[1]);

            char[][] matrix = new char[r][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
            }

            int countSquareOfEqual = 0;
            for (int row = 0; row < matrix.Length - 1; row++)
            {
                for (int col = 0; col < matrix[row].Length - 1; col++)
                {
                    if (matrix[row][col] == matrix[row][col + 1] && matrix[row][col] == matrix[row + 1][col] &&
                        matrix[row][col] == matrix[row + 1][col + 1])
                    {
                        countSquareOfEqual++;
                    }
                }
            }

            Console.WriteLine(countSquareOfEqual);
        }
    }
}
