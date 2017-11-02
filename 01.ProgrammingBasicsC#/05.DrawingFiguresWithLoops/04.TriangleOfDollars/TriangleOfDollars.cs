using System;

class TriangleOfDollars
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        for (int row = 0; row < n; row++)
        {
            Console.Write("$");
            for (int cow = 0; cow < row; cow++)
            {
                Console.Write(" $");
            }
            Console.WriteLine();
        }
    }
}

