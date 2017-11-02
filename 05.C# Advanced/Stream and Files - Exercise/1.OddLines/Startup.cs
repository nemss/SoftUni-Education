namespace _1.OddLines
{
    using System;
    using System.IO;

    public class Startup
    {
        public static void Main(string[] args)
        {
            using (var read = new StreamReader("OddLinesIn.txt"))
            {
                string currentLine = read.ReadLine();
                int counter = 0;
                while (!string.IsNullOrEmpty(currentLine))
                {
                    if (counter % 2 != 0)
                    {
                        Console.WriteLine(currentLine);
                    }        
                    
                    counter++;
                    currentLine = read.ReadLine();
                }
            }
        }
    }
}
