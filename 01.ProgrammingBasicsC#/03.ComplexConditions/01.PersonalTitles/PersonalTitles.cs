using System;

class Program
{
    static void Main()
    {
        var age = double.Parse(Console.ReadLine());
        var title = char.Parse(Console.ReadLine().ToLower());

        if (age>=16)
        {
            if (title=='m')
            {
                Console.WriteLine("Mr.");
            }
            else if (title=='f')
            {
                Console.WriteLine("Ms.");
            }
        }
        else if (age<16)
        {
            if (title=='m')
            {
                Console.WriteLine("Master");
            }
            else if (title=='f')
            {
                Console.WriteLine("Miss");
            }
        }
    }
}

