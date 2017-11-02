using System;

public class Substring
{
    public static void Main()
    {
        string text = Console.ReadLine();
        int jump = int.Parse(Console.ReadLine());

        char Search = (char)112;
        bool hasMatch = false;

        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == Search)
            {
                hasMatch = true;
                string matchedString;
                var lenght = jump + 1;
                int endIndex = jump;

                if (i + lenght <= text.Length)
                {
                    matchedString = text.Substring(i, endIndex + 1);
                }
                else
                {
                    matchedString = text.Substring(i);
                }
                Console.WriteLine(matchedString);
                i += jump;
            }
        }

        if (!hasMatch)
        {
            Console.WriteLine("no");
        }
    }
}