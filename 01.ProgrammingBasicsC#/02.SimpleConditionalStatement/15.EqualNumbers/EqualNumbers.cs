using System;

class Program
{
    static void Main()
    {
        var number = int.Parse(Console.ReadLine());
        var number1 = int.Parse(Console.ReadLine());
        var number2 = int.Parse(Console.ReadLine());

        if (number==number1 && number ==number2 && number1==number2)
        {
            Console.WriteLine("yes");
        }
        else
        {
            Console.WriteLine("no");
        }
    }
}

