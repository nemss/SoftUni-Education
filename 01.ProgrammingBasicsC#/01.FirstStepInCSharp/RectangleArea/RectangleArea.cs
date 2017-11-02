using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter a:");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Enter b:");
        int b = int.Parse(Console.ReadLine());
        int result = a * b;

        Console.WriteLine("The area is {0}:", result);
    }
}

