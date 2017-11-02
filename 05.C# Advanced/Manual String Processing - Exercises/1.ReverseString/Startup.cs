namespace _1.ReverseString
{
    using System;
    using System.Text;

    public class Startup
    {
        public static void Main(string[] args)
        { 

            string inputText = Console.ReadLine();
            
            ReverseFast(inputText);

        }

        public static void ReverseFast(string x)
        {
            string text = x;
            StringBuilder reverse = new StringBuilder();

            for (int i = text.Length - 1; i >= 0; i--)
            {
                reverse.Append(text[i]);
            }
            Console.WriteLine(reverse);
        }
    }
}
