using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class ExtractEmails
{
    static void Main()
    {
        var text = Console.ReadLine();

        var pattern = @"\b(?<!\S)(([a-z0-9\-\.]+@[a-z0-9\-]+\.[a-z]+([\.a-z]+)?))\b";
        Regex reg = new Regex(pattern);

        MatchCollection matches = reg.Matches(text);

        foreach (Match match in matches)
        {
            Console.WriteLine(match);
        }
    }
}