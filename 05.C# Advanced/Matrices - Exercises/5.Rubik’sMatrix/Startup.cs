namespace _5.Rubik_sMatrix
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var r = input[0];
            var c = input[1];
            int[][] matrix = new int[r][];

            var count = 1;
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new int[c];
                for (int col = 0; col < c; col++)
                {
                    matrix[row][col] = count;
                    count++;
                }
            }

            var commandsNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsNum; i++)
            {
                var commandTokens = Console.ReadLine()
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                var rIndex = int.Parse(commandTokens[0]);
                var direction = commandTokens[1];
                var moves = int.Parse(commandTokens[2]);

                switch (direction)
                {
                    case "up":
                        MoveCol(matrix, rIndex, moves);
                        break;
                    case "down":
                        MoveCol(matrix, rIndex, matrix.Length - moves);
                        break;
                    case "left":
                        MoveRow(matrix, rIndex, moves);
                        break;
                    case "right":
                        MoveRow(matrix, rIndex, c - moves % );
                        break;
                }

                var element = 1;
                for (int ro = 0; ro < matrix.Length; ro++)
                {
                    for (int co = 0; co < matrix[0].Length; co++)
                    {
                        if (matrix[ro][co] == element)
                        {
                            Console.WriteLine("No swap required");
                        }
                        else
                        {
                            for (int roIndex = 0; roIndex < matrix.Length; roIndex++)
                            {
                                for (int coIndex = 0; coIndex < matrix[0].Length; coIndex++)
                                {
                                    if (matrix[roIndex][coIndex] == element)
                                    {
                                        var currentElement = matrix[ro][co];
                                        matrix[ro][co] = element;
                                        matrix[roIndex][coIndex] = currentElement;
                                        Console.WriteLine($"Swap ({ro}, {co}) with ({roIndex}, {coIndex})");
                                        break;
                                    }
                                }
                            }
                        }

                        element++;
                    }
                }
            }
        }

        private static void MoveRow(int[][] matrix, int rIndex, int moves)
        {
            var temp = new int[matrix[0].Length];
            for (int col = 0; col < matrix[0].Length; col++)
            {
                temp[col] = matrix[rIndex][(col + moves) % matrix[0].Length];
            }
            matrix[rIndex] = temp;
        }

        private static void MoveCol(int[][] matrix, int rIndex, int moves)
        {
            var temp = new int[matrix.Length];
            for (int row = 0; row < matrix.Length; row++)
            {
                temp[row] = matrix[(row + moves) % matrix.Length][rIndex];
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row][rIndex] = temp[row];
            }
        }
    }
}
