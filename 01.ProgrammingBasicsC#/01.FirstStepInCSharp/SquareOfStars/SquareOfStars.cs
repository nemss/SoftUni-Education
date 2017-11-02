using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine(new string('*',n));
        for (int i = 2; i < n; i++)
        {
            
            Console.WriteLine("*" + new string(' ', n - 2) + "*");
        }
        Console.WriteLine(new string('*', n));
    }
    
}

