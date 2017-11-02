using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class ReplaceTag
{
    static void Main()
    {
        var text = Console.ReadLine();

        while (text != "end")
        {
            var pattern = @"<a.*?href.*?=(.*)>(.*?)<\/a>";
            var replace = @"[URL href=$1]$2[/URL]";

            var replaced = Regex.Replace(text, pattern, replace);

            Console.WriteLine(replaced);

            text = Console.ReadLine();
        }
    }
}