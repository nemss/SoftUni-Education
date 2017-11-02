namespace _13.MagicExchangeableWords
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var mappedChars = new Dictionary<char, char>();

            var shorterString = input[0];
            var longerString = input[1];

            if (shorterString.Length > longerString.Length)
            {
                var temp = longerString;
                longerString = shorterString;
                shorterString = temp;
            }
            bool magic = true;
            for (int i = 0; i < shorterString.Length; i++)
            {
                if (!mappedChars.ContainsKey(longerString[i]))
                {
                    mappedChars.Add(longerString[i], shorterString[i]);
                }
                else if(mappedChars[longerString[i]] != shorterString[i])
                {
                    magic = false;
                    break;
                }
            }
            if (magic)
            {
                for (int i = shorterString.Length; i < longerString.Length; i++)
                {
                    if (!mappedChars.ContainsKey(longerString[i]))
                    {
                        magic = false;
                        break;
                    }
                }
            }

            Console.WriteLine(magic.ToString().ToLower());


        }
    }
}
