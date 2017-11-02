using System;

class EnglishNameOfLastDigit
{
    static void Main()
    {
        var n = long.Parse(Console.ReadLine());

        var result = GetNameOfLastDigit(n);
        Console.WriteLine(result);
    }

    private static object GetNameOfLastDigit(long n)
    {
        var lastDigit =Math.Abs(n % 10);
        var nameOfDigit = "";
        switch (lastDigit)
        {
            case 1:
                nameOfDigit = "one";
                break;
            case 2:nameOfDigit="two";
                break;
            case 3:nameOfDigit="three";
                break;
            case 4:nameOfDigit="four";
                break;
            case 5:nameOfDigit="five";
                break;
            case 6:nameOfDigit="six";
                break;
            case 7:nameOfDigit="seven";
                break;
            case 8:nameOfDigit="eight";
                break;
            case 9:nameOfDigit="nine";
                break;
            case 0:nameOfDigit="zero";
                break;
            default:
                break;
        }
        return nameOfDigit;
    }
}