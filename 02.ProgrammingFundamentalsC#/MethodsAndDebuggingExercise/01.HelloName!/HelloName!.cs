using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    private static void Main()
    {
        Console.WriteLine("Hello, {0}!", GetName());
    }

    static string GetName()
    {
        var name = Console.ReadLine();
        return name;
    }
}