using System;

class BlankReceipt
{
    static void Main()
    {
        PrintReceipt();
    }

    private static void PrintReceipt()
    {
        PrintRecieptHeader();
        PrintRecieptBody();
        PrintRecieptFooter();
    }

    private static void PrintRecieptFooter()
    {
        Console.WriteLine("\u00A9"+" SoftUni");
    }

    private static void PrintRecieptBody()
    {
        Console.WriteLine("Charged to____________________");
        Console.WriteLine("Received by___________________");
        Console.WriteLine("------------------------------");
    }

    private static void PrintRecieptHeader()
    {
        Console.WriteLine("CASH RECEIPT");
        Console.WriteLine("------------------------------");
    }
}