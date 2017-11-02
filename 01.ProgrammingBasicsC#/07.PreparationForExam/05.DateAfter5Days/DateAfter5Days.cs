using System;

class DateAfter5Days
{
    static void Main()
    {
        var days = int.Parse(Console.ReadLine());
        var month = int.Parse(Console.ReadLine());

        var daysOfMonth = 31;
        days += 5;

        if (month==4 || month == 6 || month == 4 || month == 11)
        {
            daysOfMonth = 30;
        }
        else if (month==2)
        {
            daysOfMonth = 28;
        }
        if (days > daysOfMonth)
        {
            days = days - daysOfMonth;
            month++;
            if (month == 13)
            {
                month = 1;
            }
        }
        if (month < 10)
        {
            Console.WriteLine("{0}.0{1}", days, month);

        }
        else
        {
            Console.WriteLine("{0}.{1}", days, month);

        }
    }
}

