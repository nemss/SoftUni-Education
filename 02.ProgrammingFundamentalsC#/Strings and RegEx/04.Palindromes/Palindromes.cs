using System;
using System.Collections.Generic;
using System.Linq;

class Palindromes
{
    static void Main()
    {
        List<string> text = Console.ReadLine().Split(new char[] { ' ', ',', '?', '!', '.' }, StringSplitOptions.RemoveEmptyEntries).ToList();

        List<string> result = new List<string>();

        foreach (var word in text.Distinct().OrderBy(w => w))
        {
            if (word == string.Join("", word.Reverse()))
            {
                result.Add(word);
            }
        }
        Console.WriteLine(string.Join(", ", result));
    }
}