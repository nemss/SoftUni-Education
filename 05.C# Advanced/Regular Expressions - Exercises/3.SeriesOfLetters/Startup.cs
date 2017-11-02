namespace _3.SeriesOfLetters
{
    using System;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var result = Regex.Replace(input, @"([A-Za-z])\1+", "$1");

            Console.WriteLine(result);
        }
    }
}
