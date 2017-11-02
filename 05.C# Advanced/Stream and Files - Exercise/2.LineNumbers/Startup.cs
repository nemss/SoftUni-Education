namespace _2.LineNumbers
{
    using System.IO;

    public class Startup
    {
        public static void Main(string[] args)
        {
            using (var read = new StreamReader("LinesIn.txt"))
            using (var write = new StreamWriter("../../result.txt"))
            {
                var currentLine = string.Empty;
                int counter = 1;
                while ((currentLine = read.ReadLine()) != null)
                {

                    write.WriteLine($"{counter}. {currentLine}");
                    counter++;

                }
            }
        }
    }
}
