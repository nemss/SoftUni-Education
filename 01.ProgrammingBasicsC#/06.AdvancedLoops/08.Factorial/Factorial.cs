using System;

class Factorial
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var factorial = 1;

        do
        {
            factorial *= n;
            n--;
        } while (n>1);
        Console.WriteLine(factorial);
    }
}

