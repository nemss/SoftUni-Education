using System;

class Increasing4Numbers
{
    static void Main()
    {
        var a = int.Parse(Console.ReadLine());
        var b = int.Parse(Console.ReadLine());
        bool isNo = true;

        for (int n1 = a; n1 <= b; n1++)
        {
            for (int n2 = n1 + 1; n2 < b; n2++)
            {
                for (int n3 = n2 + 1; n3 < b; n3++)
                {
                    for (int n4 = n3 + 1; n4 <= b; n4++)
                    {
                        Console.WriteLine("{0} {1} {2} {3}", n1, n2, n3, n4);
                        isNo = false;
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