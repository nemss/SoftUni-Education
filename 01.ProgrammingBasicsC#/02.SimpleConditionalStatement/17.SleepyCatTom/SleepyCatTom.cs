using System;

class SleepyCatTom
{
    static void Main()
    {
        var freeDays = int.Parse(Console.ReadLine());
        var tomNormMinutes = 30000;
        var workDays = 365 - freeDays;
        var totalPlay = (workDays * 63) + (freeDays * 127);

        var minutesDifference = tomNormMinutes - totalPlay;

        var hour = Math.Abs(minutesDifference / 60);
        var min = Math.Abs(minutesDifference % 60);

        if (tomNormMinutes < totalPlay)
        {
            Console.WriteLine("Tom will run away");
            Console.WriteLine("{0} hours and {1} minutes more for play", hour, min);
        }
        else
        {
            Console.WriteLine("Tom sleeps well");
            Console.WriteLine("{0} hours and {1} minutes less for play", hour, min);
        }



    }
}

