using System;
using System.Collections.Generic;
using System.Linq;

class MagicExchangeableWords
{
    static void Main()
    {
        var input = Console.ReadLine().Split().ToList();

        var first = input[0];
        var sec = input[1];

        if (first.Length==sec.Length)
        {
            Console.WriteLine("true");
        }
        else
        {
            Console.WriteLine("false");
        }
        
    }
}