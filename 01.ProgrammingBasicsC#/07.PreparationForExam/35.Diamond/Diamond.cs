using System;

class Diamond
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var dot = n - 1;
        var stars = n * 3;

        Console.WriteLine(new string('.', n)+new string('*', n*3)+ new string('.', n));
        for (int i = 0; i < n-1; i++)
        {
            Console.WriteLine(new string('.', n-1-i)+"*" +new string('.', stars)+"*"+ new string('.', n-1-i));
            stars +=2;
        }
        Console.WriteLine(new string('*', n*5));
        for (int i = 0; i <n*2; i++)
        {
            Console.WriteLine(new string('.', i+1) + "*" + new string('.', stars-2) + "*" + new string('.',  i+1));
            stars -=2;
        }
        Console.WriteLine(new string('.', n*2+1) + new string('*', n -2) + new string('.', n*2+1));
    }
}

