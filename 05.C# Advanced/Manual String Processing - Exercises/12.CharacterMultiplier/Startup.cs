namespace _12.CharacterMultiplier
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            var firstString = input[0];
            var secondString = input[1];
            var sum = 0;

            if (firstString.Length == secondString.Length)
            {
                for (int i = 0; i < firstString.Length; i++)
                {
                    sum += (int)firstString[i] * (int)secondString[i];
                }
            }
            else if (firstString.Length > secondString.Length)
            {
                for (int i = 0; i < firstString.Length; i++)
                {
                    if (secondString.Length > i)
                    {
                        sum += (int)firstString[i] * (int)secondString[i];
                    }
                    else
                    {
                        sum += (int)firstString[i];
                    }
                }
            }
            else if (firstString.Length < secondString.Length)
            {
                for (int i = 0; i < secondString.Length; i++)
                {
                    if (firstString.Length > i)
                    {
                        sum += (int)firstString[i] * (int)secondString[i];
                    }
                    else
                    {
                        sum += (int)secondString[i];
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}
