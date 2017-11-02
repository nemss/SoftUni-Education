using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.ShortWordsSorted
{
    class ShortWordsSorted
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine().ToLower().Split(new char[] { '.', ',', ':', ';', '(', ')', '[', ']', '\\', '\"', '\'', '/', '!', '?', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                                   .Where(w => w.Length < 5)
                                                   .OrderBy(x => x)
                                                   .Distinct()
                                                   .ToArray();
            Console.WriteLine(string.Join(", ", text));
        }
    }
}
