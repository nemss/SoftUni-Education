using System;

class LeftAndRightSum
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var leftNumber = 0;
        var rightNumber = 0;

        for (int i = 0; i <n; i++)
        {
            var number = int.Parse(Console.ReadLine());
            leftNumber += number;
        }


        for (int i = 0; i < n; i++)
        {
            var number = int.Parse(Console.ReadLine());
            rightNumber += number;
        }
        if (rightNumber==leftNumber)
        {
            Console.WriteLine("Yes, sum {0}", leftNumber);
        }
        else
        {
            Console.WriteLine("No, diff {0}" ,Math.Abs(leftNumber-rightNumber));
        }
    }
}

