namespace _10.TextFilter
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var banList = Console.ReadLine()
                .Trim()
                .Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var text = Console.ReadLine();
          
            foreach (var word in banList)
            {
                text = text.Replace(word, new string('*', word.Length));
            }
                    
            Console.WriteLine(text);
        }
    }
}
