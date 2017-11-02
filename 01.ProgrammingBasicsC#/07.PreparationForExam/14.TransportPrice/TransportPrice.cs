using System;

class Program
{
    static void Main()
    {
        var kilometers = double.Parse(Console.ReadLine());
        var dayOrNight = Console.ReadLine();
        var taxiPrice = 0.70;
        var busPrice = 0.09;
        var trainPrice = 0.06;
        var sum = 0.0;

        var taxiDayOrNight = dayOrNight == "day" ? 0.79 : 0.90;

        if (kilometers<20)
        {
            sum = taxiPrice + kilometers * taxiDayOrNight;
        }
        else if (kilometers<100)
        {
            sum = busPrice * kilometers;
        }
        else if (kilometers>=100)
        {
            sum = trainPrice * kilometers;
        }
        Console.WriteLine(sum);
    }
}

