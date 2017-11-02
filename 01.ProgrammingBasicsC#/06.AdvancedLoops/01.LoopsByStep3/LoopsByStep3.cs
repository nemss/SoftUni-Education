using System;

class Numbers1ToNStep3
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i += 3)
        {
            Console.WriteLine(i);
        }
    }
}