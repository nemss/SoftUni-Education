using System;
using System.Collections.Generic;
using System.Linq;

class ExtractSentencesKeyword
{
    static void Main()
    {
        var word = Console.ReadLine().ToLower();
        var text = Console.ReadLine().Split(new char[] { '.', '!', '?'}).ToList();

        var result = new List<string>();

        foreach (var item in text)
        {
            if (item.Contains(word+" "))
            {
                result.Add(item);
            }
        }
        Console.WriteLine(string.Join("\n", result));
    }
}