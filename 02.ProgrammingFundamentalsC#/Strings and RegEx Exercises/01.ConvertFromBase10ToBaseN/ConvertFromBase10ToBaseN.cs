using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

class ConvertFromBase10ToBaseN
{
    static void Main()
    {
        var input = Console.ReadLine().Split().ToList();

        var bases = sbyte.Parse(input[0]);
        BigInteger number =BigInteger.Parse(input[1]);
        var result = "";

        while (number>0)
        {
            result = number % bases + result;
            number /= bases;
        }

        Console.WriteLine(result);
    }
}