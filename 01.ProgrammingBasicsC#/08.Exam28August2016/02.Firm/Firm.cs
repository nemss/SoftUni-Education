using System;

class Firm
{
    static void Main()
    {
        var needHours = int.Parse(Console.ReadLine());
        var days = int.Parse(Console.ReadLine());
        var workers = int.Parse(Console.ReadLine());

        double procent = days * 0.1;
        var hoursForWork =Math.Floor((days-procent) * 8);
        var overtime = workers * (2 * days);
        var allHours = hoursForWork + overtime;

        if (allHours>=needHours)
        {
            Console.WriteLine("Yes!{0} hours left.", Math.Floor(allHours-needHours));
        }
        else
        {
            Console.WriteLine("Not enough time!{0} hours needed.", Math.Floor(needHours-allHours));
        }
    }
}

