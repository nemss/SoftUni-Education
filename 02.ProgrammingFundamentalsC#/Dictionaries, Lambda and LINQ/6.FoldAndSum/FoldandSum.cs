using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.FoldAndSum
{
    class FoldandSum
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int k = arr.Length / 4;

            int[] row1Left = arr.Take(k).Reverse().ToArray();
            int[] row1right = arr.Reverse().Take(k).ToArray();
            int[] row1 = row1Left.Concat(row1right).ToArray();
            int[] row2 = arr.Skip(k).Take(2 * k).ToArray();

            var sumArr = row1.Select((x, index) => x + row2[index]);
            Console.WriteLine(string.Join(" ",sumArr));
        }
    }
}
