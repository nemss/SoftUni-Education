using System;
using System.Linq;

class HalfSumElement
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var sum = 0;
        var maxNumber = 0;

        for (int i = 0; i < n; i++)
        {
            var number = int.Parse(Console.ReadLine());
            maxNumber= Math.Max(maxNumber, number);
            sum += number;
        }
        if (sum-maxNumber==maxNumber)
        {
            Console.WriteLine("Yes, Sum {0}",sum/2);
        }
        else
        {
            Console.WriteLine("No, Diff {0}",Math.Abs(maxNumber-(sum-maxNumber)));
        }
    }
}