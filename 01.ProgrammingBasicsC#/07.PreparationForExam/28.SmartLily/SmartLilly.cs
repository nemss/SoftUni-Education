using System;

class SmartLilly
{
    static void Main()
    {
        var lillyAge = int.Parse(Console.ReadLine());
        var loundryPrace = double.Parse(Console.ReadLine());
        var toyPrice = int.Parse(Console.ReadLine());
        var lillyToys = 0;
        var money  = 10.00;
        var lillyMoney = 0.00;
        var brotherMoney = 0.00;
        for (int i = 1; i <= lillyAge; i++)
        {
            if (i%2==0)
            {
                lillyMoney+= money;
                brotherMoney +=1.00;
                money += 10.00;
            }
            else
            {
                lillyToys++;
            }
        }
        var lilySellToys = lillyToys * toyPrice;
        var allSum = lillyMoney + lilySellToys - brotherMoney;
        if (allSum>=loundryPrace)
        {
            Console.WriteLine("Yes! {0:f2}", allSum-loundryPrace);
        }
        else
        {
            Console.WriteLine("No! {0:f2}", loundryPrace-allSum);
        }
    }
}

