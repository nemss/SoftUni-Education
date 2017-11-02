using System;
using System.Linq;
class GreaterOfTwoValues
{
    static void Main()
    {
        var type = Console.ReadLine().ToLower();

        if (type == "int")
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            var max=MaxInt(first, second);
            Console.WriteLine(max);
        }
        else if (type == "char")
        {
            var first = char.Parse(Console.ReadLine());
            var second = char.Parse(Console.ReadLine());
            var max = MaxChar(first, second);
            Console.WriteLine(max);
        }
        else if (type == "string")
        {
            var first = Console.ReadLine();
            var second = Console.ReadLine();
            var max = MaxString(first, second);
            Console.WriteLine(max);
        }
    }


    private static int MaxInt(int first, int second)
    {
        if (first>=second)
        {
            return first;
        }
        else
        {
            return second;
        }
    }

    private static char MaxChar(char first, char second)
    {
        if (first>=second)
        {
            return first;
        }
        else
        {
            return second;
        }
    }

    private static string MaxString(string first, string second)
    {
        if (first.CompareTo(second)==0)
        {
            return first;
        }
        else
        {
            return second;
        }
    }
}