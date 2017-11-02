using System;

class OddEvenSum
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var oddNumber = 0;
        var evenNumber = 0;

        for (int i = 0; i < n; i++)
        {
            var number = int.Parse(Console.ReadLine());
            if (i %2==0)
            {
                evenNumber += number;
            }
            else
            {
                oddNumber += number;
            }
        }
        if (evenNumber==oddNumber)
        {
            Console.WriteLine("Yes, Sum {0}", evenNumber);
        }
        else
        {
            Console.WriteLine("No, Diff {0}",Math.Abs(evenNumber-oddNumber));
        }
    }
}

