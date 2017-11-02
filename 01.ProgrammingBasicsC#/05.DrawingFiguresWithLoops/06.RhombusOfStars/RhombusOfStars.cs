using System;

class Program
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.Write(new string(' ', n - 1 - i));
            for (int j = 0; j < i + 1; j++)
            {
                Console.Write("* ");
            }
            Console.WriteLine();
        }
        for (int i = 0; i < n - 1; i++)
        {
            Console.Write(new string(' ', i + 1));
            for (int j = 0; j < n - 1 - i; j++)
            {
                Console.Write("* ");
            }
            Console.WriteLine();
        }
    }
}

