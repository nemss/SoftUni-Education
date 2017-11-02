namespace _4.SpecialWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var dic = new Dictionary<string, int>();
            var specialWord = Console.ReadLine()
                .Split(new[] { '(', ')', '[', ']', '<', '>', '-', '?', ' ' })
                .ToList();

            var text = Console.ReadLine()
                .Split(new[] { '(', ')', '[', ']', '<', '>', '-', '?', ' ' })
                .ToList();

            foreach (var e in specialWord)
            {
                if (!dic.ContainsKey(e))
                {
                    dic[e] = 0;
                }
                foreach (var t in text)
                {
                    if (e.Equals(t))
                    {
                        dic[e] += 1;
                    }
                }
            }

            foreach (var element in dic)
            {
                Console.WriteLine($"{element.Key} - {element.Value}");
            }
        }
    }
}
