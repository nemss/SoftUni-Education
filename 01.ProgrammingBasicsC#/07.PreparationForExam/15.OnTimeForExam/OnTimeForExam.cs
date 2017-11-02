using System;

class OnTimeForExam
{
    static void Main()
    {
        var examHours = int.Parse(Console.ReadLine());
        var examMinutes = int.Parse(Console.ReadLine());
        var studentHours = int.Parse(Console.ReadLine());
        var studentMinutes = int.Parse(Console.ReadLine());

        var examTime = examHours * 60 + examMinutes;
        var studentTime = studentHours * 60 + studentMinutes;
        var minutesDifference = studentTime - examTime;

        if (minutesDifference < -30)
        {
            Console.WriteLine("Early");
        }
        else if (minutesDifference <= 0)
        {
            Console.WriteLine("On time");
        }
        else
        {
            Console.WriteLine("Late");
        }
        if (minutesDifference != 0)
        {
            var hours = Math.Abs(minutesDifference / 60);
            var minutes = Math.Abs(minutesDifference % 60);
            if (hours > 0)
            {
                if (minutes < 10)
                {
                    Console.Write(hours + ":0" + minutes + " hours");
                }
                else
                {
                    Console.Write(hours + ":" + minutes + " hours");
                }
            }
            else
            {
                Console.Write(minutes + " minutes");
            }
            if (minutesDifference < 0)
            {
                Console.WriteLine(" before the start");
            }
            else
            {
                Console.WriteLine(" after the start");
            }
        }
    }
}
