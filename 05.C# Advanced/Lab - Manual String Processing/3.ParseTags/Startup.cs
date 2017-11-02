namespace _3.ParseTags
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var openTag = "<upcase>";
            var closeTag = "</upcase>";

            int startIndex = input.IndexOf(openTag);
            while (startIndex != -1)
            {
                int endIndex = input.IndexOf(closeTag);
                if (endIndex == -1)
                {
                    break;
                }

                var toBeReplace = input.Substring(startIndex, endIndex + closeTag.Length - startIndex);

                var replace = toBeReplace.Replace(openTag, string.Empty).Replace(closeTag, string.Empty).ToUpper();

                input = input.Replace(toBeReplace, replace);

                startIndex = input.IndexOf(openTag);
            }
            Console.WriteLine(input);
        }
    }
}
