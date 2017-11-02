using System;

class Butterfly
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        Console.WriteLine(new string('*', n-2)+"\\"+" "+"/"+ new string('*', n - 2));
        for (int i = 0; i < n/2-1; i++)
        {
            Console.WriteLine(new string('-', n-2)+ "\\" + " " + "/" + new string('-', n - 2));
            Console.WriteLine(new string('*', n - 2) + "\\" + " " + "/" + new string('*', n - 2));
        }
        Console.WriteLine(new string(' ', n-1)+"@"+ new string(' ', n - 1));
        for (int i = 0; i < n/2-1; i++)
        {
            Console.WriteLine(new string('*', n - 2) + "/" + " " + "\\" + new string('*', n - 2));
            Console.WriteLine(new string('-', n - 2) + "/" + " " + "\\" + new string('-', n - 2));            
        }
        Console.WriteLine(new string('*', n - 2) + "/" + " " + "\\" + new string('*', n - 2));
    }
}

