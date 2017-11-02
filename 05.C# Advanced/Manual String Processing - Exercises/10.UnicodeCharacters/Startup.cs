namespace _10.UnicodeCharacters
{
    using System;
    using System.Text;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var text = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            foreach (char c in text)
            {
                sb.Append("\\u");
                sb.Append(String.Format("{0:x4}", (int)c));
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
