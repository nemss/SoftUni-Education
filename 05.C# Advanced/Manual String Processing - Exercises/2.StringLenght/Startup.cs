namespace _2.StringLenght
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();

            if (input.Length < 20)
            {
                Console.WriteLine(input.PadRight(20, '*'));
            }
            else if (input.Length == 20)
            {
                Console.WriteLine(input);
            }
            else if (input.Length > 20)
            {
                Console.WriteLine(input.Substring(0, 20));
            }
        }
    }
}
