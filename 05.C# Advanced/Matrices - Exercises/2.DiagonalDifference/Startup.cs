namespace _2.DiagonalDifference
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var matrixSize = int.Parse(Console.ReadLine());

            int[][] matrix = new int[matrixSize][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            }
            int primaryDiagonal = 0;
            int secondoryDiagonal = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    primaryDiagonal += matrix[i][i];
                    secondoryDiagonal += matrix[i][matrix.Length - i - 1];
                }
            }

            Console.WriteLine(Math.Abs(primaryDiagonal - secondoryDiagonal));
        }
    }
}
