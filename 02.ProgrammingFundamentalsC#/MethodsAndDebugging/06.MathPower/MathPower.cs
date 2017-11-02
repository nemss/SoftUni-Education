using System;

class MathPower
{
    static void Main()
    {
        var number = double.Parse(Console.ReadLine());
        var pow = double.Parse(Console.ReadLine());
        var res = MathPow(number, pow);
        Console.WriteLine(res);
    }

    static double MathPow(double number, double pow)
    {
        return Math.Pow(number, pow);
    }
}