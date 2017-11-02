using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace _3.CubicMessages
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            //(^\d+)([a-zA-Z]+)([^a-zA-Z]*$)
            var patternValid = @"(^\d+)([a-zA-Z]+)([^a-zA-Z]*$)";
            

            string inputMessage;
            while (!(inputMessage = Console.ReadLine()).Equals("Over!"))
            {
                var messageLenght = int.Parse(Console.ReadLine());
                var match = Regex.Match(inputMessage, patternValid);

                if (match.Success)
                {
                    var prefix = match.Groups[1].Value;
                    var message = match.Groups[2].Value;
                    var ending = match.Groups[3].Value;

                    if (message.Length != messageLenght)
                    {
                        continue;
                    }

                    var indexes = Regex.Replace(prefix + ending, @"\D*", string.Empty);
                    var sb = new StringBuilder();
                    foreach (var index in indexes)
                    {
                        var ind = int.Parse(index.ToString());
                        if (ind >= 0 && ind < messageLenght)
                        {
                            sb.Append(message[ind]);
                        }
                        else
                        {
                            sb.Append(" ");
                        }
                    }

                    Console.WriteLine($"{message} == {sb}");
                }
            }
        }
    }
}
