using System;
using System.Collections.Generic;
using System.Linq;

class ReverseString
{
    static void Main()
    {
        var str = Console.ReadLine();
        var reversed = str.ToCharArray().Reverse();

        Console.WriteLine(string.Join("", reversed));
    }
}