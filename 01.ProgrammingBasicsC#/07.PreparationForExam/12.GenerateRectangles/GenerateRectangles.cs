using System;

class GenerateRectangles
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var m = int.Parse(Console.ReadLine());
        bool isNo = true;

        for (int left = -n; left < n; left++)
        {
            for (int right = left + 1; right <= n; right++)
            {
                for (int top = -n; top < n; top++)
                {
                    for (int bottom = top + 1; bottom <= n; bottom++)
                    {
                        var a = bottom - top;
                        var b = right - left;
                        var area = a * b;
                        if (area >= m)
                        {
                            Console.WriteLine("({0}, {1}) ({2}, {3}) -> {4}", left, top, right, bottom, area);
                            isNo = false;
                        }
                    }
                }
            }
        }
        if (isNo)
        {
            Console.WriteLine("No");
        }
    }
}