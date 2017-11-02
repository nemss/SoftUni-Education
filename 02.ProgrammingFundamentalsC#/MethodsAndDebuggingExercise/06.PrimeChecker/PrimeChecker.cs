using System;

class PrimeChecker
{
    static void Main()
    {
        var n = long.Parse(Console.ReadLine());

        
        var result = IsPrime(n);
        Console.WriteLine(result);
    }

    private static object IsPrime(long n)
    {
        bool isPrime = true;
        if (n<2)
        {
            isPrime = false;
        }
        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0)
            {
                isPrime = false;
            }
        }
        return isPrime;
    }
}