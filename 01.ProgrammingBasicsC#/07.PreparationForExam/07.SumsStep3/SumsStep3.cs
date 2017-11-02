using System;

class SumsStep3
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var sum1 = 0;
        var sum2 = 0;
        var sum3 = 0;
        var count1 = 1;
        var count2 = 2;
        var count3 = 3;

        for (int i = 1; i <= n; i++)
        {
            var num = int.Parse(Console.ReadLine());

            if (i == count1)
            {
                sum1 += num;
                count1 += 3;
            }
            else if (i == count2)
            {
                sum2 += num;
                count2 += 3;
            }
            else if (i == count3)
            {
                sum3 += num;
                count3 += 3;
            }
        }
        Console.WriteLine("sum1 = {0}", sum1);
        Console.WriteLine("sum2 = {0}", sum2);
        Console.WriteLine("sum3 = {0}", sum3);
    }
}

