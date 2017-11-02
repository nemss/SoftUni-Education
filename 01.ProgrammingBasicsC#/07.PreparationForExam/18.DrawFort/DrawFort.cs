using System;

class DrawFort
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var huts =  n / 2;
        var dashes = (2*n)-2*(huts)-4;

        Console.WriteLine("/"+new string('^',huts)+"\\"+new string('_',dashes)+"/"+new string('^', huts)+"\\");
        for (int i = 0; i < n-3; i++)
        {
            Console.Write("|");           
            Console.Write(new string(' ', 2 * n - 2));
            Console.WriteLine("|");
        }
        Console.WriteLine("|"+new string(' ',huts+1)+new string('_', dashes)+new string(' ', huts+1)+"|");
        Console.WriteLine("\\"+new string('_', huts)+"/"+new string(' ', dashes)+"\\"+ new string('_', huts) + "/");
    }
}

