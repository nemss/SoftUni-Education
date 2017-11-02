using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        GetFactorial(n);
    }

    private static void GetFactorial(int n)
    {
        var count = 0;
        BigInteger factorial = 1;

        for (int i = n; i > 1; i--)
        {
            factorial = BigInteger.Multiply(factorial, i);
        }
        //string factorialString = Convert.ToString(factorial);

        //for (int i =factorialString.Length - 1; i >= 0; i--)
        //{
        //    if (factorialString[i] =='0')
        //    {
        //        count++;
        //    }
        //    else
        //    {
        //        break;
        //    }
        //}
        while (factorial % 10 == 0)
        {
            count++;
            factorial /= 10;
        }
        Console.WriteLine(count);
    }
}