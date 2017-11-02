using System;

class Sunglasses
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        Console.WriteLine(new string('*',n*2)+new string(' ',n)+ new string('*', n * 2));
        for (int row = 0; row < n-2; row++)
        {
            Console.Write("*" + new string('/', 2 * n - 2) + "*");
            if (row == (n - 1) / 2 - 1)
            {
                Console.Write(new string('|', n));
            }
            else
            {
                Console.Write(new string(' ', n));
            }
            Console.Write("*"+new string('/', 2 * n - 2) + "*");
            Console.WriteLine();
        }
         Console.WriteLine(new string('*',n*2)+new string(' ',n)+ new string('*', n * 2));

    }
}

