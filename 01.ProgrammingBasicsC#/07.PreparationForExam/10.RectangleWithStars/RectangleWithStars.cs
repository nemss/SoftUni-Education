using System;

class Program
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        var rows = n;
        if (rows % 2 == 0)
        {
            rows--;
        }
        Console.WriteLine(new string('%', n * 2));
        for (int row = 0; row < rows; row++)
        {
            Console.Write("%");
            if (row == (n - 1) / 2)
            {
                Console.Write(new string(' ', n - 2) + "**" + new string(' ', n - 2));
            }
            else
            {
                Console.Write(new string(' ', 2 * n - 2));
            }
            Console.Write("%");
            Console.WriteLine();
        }
        Console.WriteLine(new string('%', n * 2));
    }
}

