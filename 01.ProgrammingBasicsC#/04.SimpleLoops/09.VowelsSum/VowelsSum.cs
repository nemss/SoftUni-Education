using System;

class Program
{
    static void Main()
    {
        var s = Console.ReadLine();
        var sum = 0;

        for (int i = 0; i < s.Length; i++)
        {
            char symbol = s[i];
            if (symbol=='a')
            {
                sum++;
            }
            else if (symbol=='e')
            {
                sum += 2;
            }
            else if (symbol == 'i')
            {
                sum += 3;
            }
            else if (symbol == 'o')
            {
                sum += 4;
            }
            else if (symbol == 'u')
            {
                sum += 5;
            }
            
        }
        Console.WriteLine(sum);


    }
}

