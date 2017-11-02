using System;

class BackToThePast
{
    static void Main()
    {
        var money = double.Parse(Console.ReadLine());
        var year = int.Parse(Console.ReadLine());
        var ivanYear = 18;
        var ivanMoney = money;

        for (int i = 1800; i <= year; i++)
        {
            if (i %2==0)
            {
                ivanMoney -= 12000;
            }
            else
            {
                ivanMoney -= 12000 + (ivanYear * 50);
            }
            ivanYear++;
        }
        if (ivanMoney>=0)
        {
            Console.WriteLine("Yes! He will live a carefree life and will have {0:f2} dollars left.", ivanMoney);
        }
        else
        {
            Console.WriteLine("He will need {0:f2} dollars to survive.", Math.Abs(ivanMoney));
        }
    }
}

