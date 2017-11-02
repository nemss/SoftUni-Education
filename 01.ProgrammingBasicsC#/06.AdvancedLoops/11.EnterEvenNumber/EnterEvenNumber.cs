using System;

class EnterEvenNumber
{
    static void Main()
    {
        int n;
        do
        {
            try
            {
                Console.Write("Enter even number:");
                n = int.Parse(Console.ReadLine());
                if (n%2==0)
                {
                    break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number");
                
            }

        } while (true);
        Console.WriteLine("Even number entered:"+n);
    }
}

