using System;

class Program
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        PrintHeader(n);
        for (int i = 0; i < n-2; i++)
        {
            PrintMiddle(n, '-');
        }
        PrintHeader(n);

    }

    private static void PrintMiddle(int n, char ch)
    {
        Console.Write(ch);
        for (int i = 1; i < n; i++)
        {
            Console.Write("\\/");
        }
        Console.WriteLine(ch);
    }

    private static void PrintHeader(int n)
    {
        Console.WriteLine(new string('-', n*2));
    }
}