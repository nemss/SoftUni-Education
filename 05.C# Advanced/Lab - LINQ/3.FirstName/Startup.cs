namespace _3.FirstName
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .OrderBy(n => n);
                
            var letters = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .OrderBy(n => n);

            var result = string.Empty;
            foreach (var letter in letters)
            {
                result = input
                    .FirstOrDefault(w => w.ToLower().StartsWith(letter.ToLower()));

                if (result != null)
                {
                    Console.WriteLine(result);
                    return;
                }
            }

            Console.WriteLine("No match");
        }
    }
}
