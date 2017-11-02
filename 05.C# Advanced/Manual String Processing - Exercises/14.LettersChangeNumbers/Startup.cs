namespace _14.LettersChangeNumbers
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new char[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);

            var result = 0.0;
            for (int i = 0; i < input.Length; i++)
            {
                var currentElement = input[i];
                var firstCharacter = currentElement[0];
                var lastCharacter = currentElement[currentElement.Length - 1];
                var number = double.Parse(currentElement.Substring(1, currentElement.Length - 2));

                var alphaPosition = firstCharacter % 32;
                if (char.IsLower(firstCharacter))
                {
                    number *= alphaPosition;
                }
                else
                {
                    number /= alphaPosition;
                }
                alphaPosition = lastCharacter % 32;
                if (char.IsLower(lastCharacter))
                {
                    number += alphaPosition;
                }
                else
                {
                    number -= alphaPosition;
                }

                result += number;
            }

            Console.WriteLine($"{result:f2}");
        }
    }
}
