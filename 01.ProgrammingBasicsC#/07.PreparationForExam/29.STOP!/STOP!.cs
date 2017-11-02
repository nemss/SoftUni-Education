using System;

class Program
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var dashes = n * 2 - 1;
        Console.WriteLine(new string('.', n+1)+new string('_', (n*2)+1)+new string('.', n + 1));
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(new string('.',n-i)+"//"+new string('_', dashes)+"\\\\"+ (new string('.', n - i)));
            dashes += 2;
        }
        Console.WriteLine("//"+new string('_', (n*2)-3)+"STOP!"+ new string('_', (n * 2) - 3)+"\\\\");

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(new string('.', i) + "\\\\" + new string('_', dashes) + "//" + (new string('.', i)));
            dashes -= 2;
        }
    }
}

