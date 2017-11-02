using System;

class PrintingTriangle
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        PrintTriangle(n);    
    }

    private static void PrintTriangle(int n)
    {
        PrintHeader(n);
        PrintFooter(n);
    }

    private static void PrintHeader(int n)
    {
        for (int row = 1; row <= n; row++)
        {
            for (int col = 1; col <= row - 1; col++)
            {
                Console.Write(col + " ");
            }

            Console.WriteLine(row);
        }
    }

    private static void PrintFooter(int n)
    {
        for (int row = n - 1; row >= 1; row--)
        {
            for (int col = 1; col <= row - 1; col++)
            {
                Console.Write(col + " ");
            }

            Console.WriteLine(row);
        }
    }
}