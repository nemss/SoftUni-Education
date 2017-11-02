namespace _4.MaximalSum
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

            int[][] matrix = new int[r][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            var maxSquareRow = 0;
            var maxSquareCol = 0;
            var sum = int.MinValue;

            for (int row = 0; row < matrix.Length - 2; row++)
            {
                for (int col = 0; col < matrix[row].Length - 2; col++)
                {
                    int currentSum = 0;
                    currentSum = matrix[row][col] + matrix[row][col + 1] + matrix[row][col + 2] +
                          matrix[row + 1][col] + matrix[row + 1][col + 1] + matrix[row + 1][col + 2] +
                          matrix[row + 2][col] + matrix[row + 2][col + 1] + matrix[row + 2][col + 2];

                    if (currentSum > sum)
                    {
                        sum = currentSum;
                        maxSquareCol = col;
                        maxSquareRow = row;
                    }
                }
            }

            PrintTheElementMatrix(matrix, maxSquareRow, maxSquareCol, sum);
        }

        private static void PrintTheElementMatrix(int[][] matrix, int maxSquareRow, int maxSquareCol, int sum)
        {
            Console.WriteLine($"Sum = {sum}\r\n " +
                              $"{matrix[maxSquareRow][maxSquareCol]} {matrix[maxSquareRow][maxSquareCol + 1]} {matrix[maxSquareRow][maxSquareCol + 2]}\r\n" +
                              $"{matrix[maxSquareRow + 1][maxSquareCol]} {matrix[maxSquareRow + 1][maxSquareCol + 1]} {matrix[maxSquareRow + 1][maxSquareCol + 2]}\r\n" +
                              $"{matrix[maxSquareRow + 2][maxSquareCol]} {matrix[maxSquareRow + 2][maxSquareCol + 1]} {matrix[maxSquareRow + 2][maxSquareCol + 2]}");
        }
    }
}
