namespace _5.ConcatenateStrings
{
    using System;
    using System.Text;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var sb = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                sb.Append(input).Append(" ");
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
