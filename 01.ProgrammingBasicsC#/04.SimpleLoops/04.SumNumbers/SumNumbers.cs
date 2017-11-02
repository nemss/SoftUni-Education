using System;

class Program
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var sum = 0;

        for (int i = 0; i < n; i++)
        {
            var number = int.Parse(Console.ReadLine());
            sum += number;
        }
        Console.WriteLine(sum);
    }
}

