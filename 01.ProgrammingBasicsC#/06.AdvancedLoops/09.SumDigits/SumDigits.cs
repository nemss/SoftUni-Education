using System;

class SumDigits
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var sum = 0;

        do
        {
            sum += n % 10;
            n = n / 10;
        } while (n >0);
        Console.WriteLine(sum);
        

    }
}

