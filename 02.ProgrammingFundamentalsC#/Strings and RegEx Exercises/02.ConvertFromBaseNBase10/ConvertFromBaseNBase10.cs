using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

class ConvertFromBaseNBase10
{
    static void Main()
    {
        string[] input = Console.ReadLine().Trim().Split();
        int number = int.Parse(input[0]);
        char[] toBase = input[1].ToCharArray();

        BigInteger result = new BigInteger(0);

        for (int i = 0; i < toBase.Length; i++)
        {
            int currentNum = (int)Char.GetNumericValue(toBase[i]);
            result += currentNum * BigInteger.Pow(number, toBase.Length - i - 1);
        }

        Console.WriteLine(result);
    }
}