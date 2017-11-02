using System;

class Program
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var min = int.MaxValue;

        for (int i = 0; i < n; i++)
        {
            var number = int.Parse(Console.ReadLine());

            if (number<min)
            {
                min = number;
            }
        }
        Console.WriteLine(min);
    }
}

