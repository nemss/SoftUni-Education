using System;

class MagicNumbers
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        for (int i = 0; i <= 9; i++)
        {
            for (int j = 1; j <= 9; j++)
            {
                for (int k  = 1; k <= 9; k++)
                {
                    for (int l  = 1; l <= 9; l++)
                    {
                        for (int m = 1; m <=9; m++)
                        {
                            for (int o =1; o <= 9; o++)
                            {
                                if (i * j * k * l * m * o==n)
                                {
                                    var magiNumber = "" + i + j + k + l + m + o;
                                    Console.Write("{0} ", magiNumber);
                                }
                            }
                        }
                    }
                }
            }
        }
        Console.WriteLine();
    }
}

