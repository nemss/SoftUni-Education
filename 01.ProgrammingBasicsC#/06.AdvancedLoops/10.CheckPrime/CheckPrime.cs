using System;

class CheckPrime
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        bool isPrime = true;

        if (n<=1)
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
        if (isPrime==true)
        {
            Console.WriteLine("Prime");
        }
        else
        {
            Console.WriteLine("Not prime");
        }
    }
}

