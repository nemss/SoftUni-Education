using System;

class FibonacciNumbers
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        long result = GetFibNum(n);
        Console.WriteLine(result);
    }

    private static int GetFibNum(int n)
    {
        var fi1 = 1;
        var fi2 = 0;
        var nextNumber = 0;
        for (int i = 0; i <= n; i++)
        {
            nextNumber = fi1+fi2;
            fi1 = fi2;
            fi2 = nextNumber;
        }
        return fi2;
    }
}