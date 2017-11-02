using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Text;

class UnicodeCharacters
{
    static void Main()
    {
        var input = Console.ReadLine();

        foreach (char chr in input)
        {
            Console.Write("\\u{0:x4}", (int)chr);
        }
        Console.WriteLine();
    }
}