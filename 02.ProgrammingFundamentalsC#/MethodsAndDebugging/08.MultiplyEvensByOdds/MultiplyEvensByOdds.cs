using System;

class MultiplyEvensByOdds
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var result = GetMultipleOfEvensAndOdds(Math.Abs(n));
        Console.WriteLine(result);
    }

    private static int GetMultipleOfEvensAndOdds(int n)
    {
        int sumEven = GetSumEven(n);
        int sumOdd = GetSumOdd(n);
        return sumEven * sumOdd;
    }

    static int GetSumOdd(int n)
    {
        var sum = 0;
        while (n>0)
        {
            var lastDigit =n % 10;
            if (lastDigit % 2 !=0)
            {
                sum += lastDigit;
            }
            n /= 10;
        }
        return sum;
    }

    static int GetSumEven(int n)
    {
        var sum = 0;
        while (n > 0)
        {
            var lastDigit = n % 10;
            if (lastDigit % 2 == 0)
            {
                sum +=lastDigit;
            }
            n /= 10;
        }
        return sum;
    }
}