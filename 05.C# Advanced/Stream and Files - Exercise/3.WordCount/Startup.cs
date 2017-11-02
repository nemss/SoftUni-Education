namespace _3.WordCount
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var dict = new Dictionary<string, int>();
            var list = new List<string>();

            using (var readerWords = new StreamReader("words.txt"))
            using (var readText = new StreamReader("text.txt"))
            using (var writer = new StreamWriter("../../result.txt"))
            {
                var currentLineWord = string.Empty;
                while ((currentLineWord = readerWords.ReadLine()) != null)
                {
                    list.Add(currentLineWord);
                }

                var currentLineText = string.Empty;
                while ((currentLineText = readText.ReadLine()) != null)
                {
                    var text = currentLineText.ToLower().Split(' ', '-', ',', '.').ToArray();
                    for (int i = 0; i < text.Length; i++)
                    {
                        if (list.Contains(text[i]))
                        {
                            if (dict.ContainsKey(text[i]))
                            {
                                dict[text[i]]++;
                            }
                            else
                            {
                                dict[text[i]] = 1;
                            }
                        }
                    }
                }

                foreach (var element in dict)
                {
                    writer.WriteLine($"{element.Key} - {element.Value}");
                }
            }
           
        }
    }
}
