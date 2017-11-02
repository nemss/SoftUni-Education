using System;

class Program
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var max =int.MinValue;

        for (int i = 0; i < n; i++)
        {
            var number = int.Parse(Console.ReadLine());
            if (number>max)
            {
                max = number;
                
            }
        }
        Console.WriteLine(max);
        
        
    }
}

