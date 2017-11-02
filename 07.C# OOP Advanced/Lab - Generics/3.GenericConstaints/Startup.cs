using System;

public class Startup
{
    public static void Main(string[] args)
    {
        Scale<int> scale = new Scale<int>(3, 5);
        Console.WriteLine(scale.GetHavier());
    }
}