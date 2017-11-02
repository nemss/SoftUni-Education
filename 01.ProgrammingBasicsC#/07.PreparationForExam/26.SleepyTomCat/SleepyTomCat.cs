using System;

class SleepyTomCat
{
    static void Main()
    {
        var freeDays = int.Parse(Console.ReadLine());
        var tomNeededMinToPlay = 30000;

        var workDays = 365 - freeDays;
        var timeToPlay = (workDays * 63 + freeDays * 127);
        var difference = Math.Abs( tomNeededMinToPlay - timeToPlay);
        var hours = difference / 60;
        var minutes = difference % 60;
        if (tomNeededMinToPlay>timeToPlay)
        {
            Console.WriteLine("Tom sleeps well");
            Console.WriteLine("{0} hours and {1} minutes less for play", hours, minutes);
        }
        else
        {
            Console.WriteLine("Tom will run away");
            Console.WriteLine("{0} hours and {1} minutes more for play", hours, minutes);
        }
    }
}

