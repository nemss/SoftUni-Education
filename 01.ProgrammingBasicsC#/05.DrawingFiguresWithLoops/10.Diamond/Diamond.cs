using System;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        var chertichki = (n - 1) / 2;

        for (int i = 1; i <= (n - 1) / 2; i++)
        {
            Console.Write(new string('-', chertichki));
            Console.Write("*");
            var mid = n - 2 * chertichki - 2;
            if (mid >= 0)
            {
                Console.Write(new string('-', mid));
                Console.Write("*");
            }
            Console.WriteLine(new string('-', chertichki));
            chertichki--;
        }
        for (int i = n / 2; i < n; i++)
        {

            Console.Write(new string('-', chertichki));
            Console.Write("*");
            var mid = n - 2 * chertichki - 2;
            if (mid >= 0)
            {
                Console.Write(new string('-', mid));
                Console.Write("*");
            }
            Console.WriteLine(new string('-', chertichki));
            chertichki++;

        }
    }
}
