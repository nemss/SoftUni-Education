using System;

class IncreasingElements
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var incrElemnts = 0;
        var start = 0;
        var maxLEnght = 0;

        for (var i = 1; i <= n; i++)
        {
            var num = int.Parse(Console.ReadLine());
            if (num > start || i == 0)
            {
                incrElemnts += 1;
            }
            else
            {
                incrElemnts = 1;
            }
            if (incrElemnts > maxLEnght)
            {
                maxLEnght = incrElemnts;
            }
            start = num;
        }
        Console.WriteLine(maxLEnght);
    }
}

