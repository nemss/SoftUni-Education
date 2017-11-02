using System;
using System.Linq;

class MaxMethod
{
    static void Main()
    {
        int firstNumber = int.Parse(Console.ReadLine());
        int secondNumber = int.Parse(Console.ReadLine());
        int thirdNumber = int.Parse(Console.ReadLine());

        var firstMax = GetMax(firstNumber, secondNumber);
        var secondMax = GetMax(firstMax, thirdNumber);

        Console.WriteLine(secondMax);
    }

    private static int GetMax(int firstNumber, int secondNumber)
    {
        if (firstNumber>secondNumber)
        {
            return firstNumber;
        }
        else
        {
            return secondNumber;
        }
    }
}