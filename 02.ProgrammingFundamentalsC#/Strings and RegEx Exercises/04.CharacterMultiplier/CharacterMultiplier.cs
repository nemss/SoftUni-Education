using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

class CharacterMultiplier
{
    static void Main()
    {
        var input = Console.ReadLine().Split().ToList();

        var firstStr = input[0].ToCharArray();
        var secondStr = input[1].ToCharArray();

        long sum = MultiplierChar(firstStr, secondStr);

        Console.WriteLine(sum);
    }

    static long MultiplierChar(char[] firstStr, char[] secondStr)
    {
        long sum = 0;
        var minLenght = Math.Min(firstStr.Length, secondStr.Length);
        var maxLenght = Math.Max(firstStr.Length, secondStr.Length);

        if (minLenght == maxLenght)
        {
            for (int i = 0; i < minLenght; i++)
            {
                sum += firstStr[i] * secondStr[i];
            }
        }
        else
        {
            for (int i = 0; i < minLenght; i++)
            {
                sum += firstStr[i] * secondStr[i];
            }
            if (maxLenght == firstStr.Length)
            {
                for (int i = minLenght; i <= maxLenght - minLenght; i++)
                {
                    sum += firstStr[i];
                }
            }
            else if(maxLenght==secondStr.Length)
            {
                for (int i = minLenght; i <= maxLenght - minLenght; i++)
                {
                    sum += secondStr[i];
                }
            }
        }
        return sum;
    }
}