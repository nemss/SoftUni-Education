using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.AppendLists
{
    class AppendLists
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split('|').ToList();
            var result = new List<string>();
            numbers.Reverse();

            foreach (var n in numbers)
            {
                var removeSpace = n.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                result.AddRange(removeSpace);
            }
            
               Console.WriteLine(string.Join(" ",result));
        }
    }
}
