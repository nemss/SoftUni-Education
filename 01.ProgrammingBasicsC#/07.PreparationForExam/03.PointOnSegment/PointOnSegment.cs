using System;

class PointOnSegment
{
    static void Main()
    {
        var first = int.Parse(Console.ReadLine());
        var second = int.Parse(Console.ReadLine());
        var point = int.Parse(Console.ReadLine());

        int distance1 = Math.Abs(first - point);
        int distance2 = Math.Abs(second - point);
        int nearEnd = 0;

        if (distance1 <= distance2)
        {
            nearEnd = distance1;
        }
        else
        {
            nearEnd = distance2;
        }
        if (first < second)
        {
            if (first <= point && point <= second)
            {
                Console.WriteLine("in");
                Console.WriteLine("{0}", nearEnd);
            }
            else
            {
                Console.WriteLine("out");
                Console.WriteLine("{0}", nearEnd);
            }
        }

        else if (first > second)
        {
            if (first >= point && point >= second)
            {
                Console.WriteLine("in");
                Console.WriteLine("{0}", nearEnd);
            }
            else
            {
                Console.WriteLine("out");
                Console.WriteLine("{0}", nearEnd);
            }
        }

    }
}

