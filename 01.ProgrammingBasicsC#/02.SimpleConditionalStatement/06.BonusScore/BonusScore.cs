using System;

class BonusScore
{
    static void Main()
    {
        
        Console.Write("Enter score:");
        var number = double.Parse(Console.ReadLine());
        var bonusScore = 0.0;
        var tenProcent = 10 / 100.0;
        var twentyProcent = 20 / 100.0;


        if (number>1000)
        {
            bonusScore = number * tenProcent;
        }
        else if (number >100)
        {
            bonusScore = number * twentyProcent;
        }
        else if (number <=100)
        {
            bonusScore += 5;
        }

        if (number %2==0)
        {
            bonusScore ++;
        }
        else if (number %10==5)
        {
            bonusScore += 2;
        }
        Console.WriteLine("Bonus score:{0}", bonusScore);
        Console.WriteLine("Total score:{0}", bonusScore+number);
        
    }
}

