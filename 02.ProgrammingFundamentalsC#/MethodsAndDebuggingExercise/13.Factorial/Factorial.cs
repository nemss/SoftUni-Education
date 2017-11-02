using System;
using System.Numerics;


class Factorial
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        BigInteger factorial = 1;

        for (int i = n; i > 1; i--)
        {
            factorial = BigInteger.Multiply(factorial, i);
        }
        Console.WriteLine(factorial);
    }
}