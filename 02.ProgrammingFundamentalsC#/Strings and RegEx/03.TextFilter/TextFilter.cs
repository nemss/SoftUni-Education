using System;
using System.Collections.Generic;
using System.Linq;

class TextFilter
{
    static void Main()
    {
        var banned = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var text = Console.ReadLine();

        foreach (var bannWord in banned)
        {
            if (text.Contains(bannWord))
            {
                text = text.Replace(bannWord, new string('*', bannWord.Length));
            }
        }
        Console.WriteLine(text);
    }
}