using System;
using System.Linq;

class NumbersInReversedOrder
{
    static void Main()
    {
        var n = Console.ReadLine();

        var result = ReverseDigitOrder(n);
        Console.WriteLine(result);
    }

    private static string ReverseDigitOrder(string n)
    {
        var reverse = "";
        for (int i = n.Length - 1; i >= 0; i--)
        {
            reverse += n[i] + "";
        }
        return reverse;
    }
}