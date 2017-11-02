using System;

class Secondssec
{
    static void Main()
    {
        var firstSecond = int.Parse(Console.ReadLine());
        var secondSecond = int.Parse(Console.ReadLine());
        var thirdSecond = int.Parse(Console.ReadLine());
        var sec = firstSecond + secondSecond + thirdSecond;
        var mins = 0;


         if (sec <= 59 )
        {

        }
        else if (sec >= 60 && sec <= 119)
        {
            mins++;
            sec -= 60;
        }
        else if (sec >= 120 && sec <= 179)
        {
            mins += 2;
            sec -= 120;
        }
        if (sec<10)
        {
            Console.WriteLine(mins+":0"+sec);
        }
        else
        {
            Console.WriteLine(mins + ":" + sec);
        }

    }
}

