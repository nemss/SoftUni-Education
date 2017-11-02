using System;

class Digits
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        var digit1 = n / 100;
        var digit2 =(n /10)%10;
        var digit3 = n % 10;
        var row = digit1 + digit2;
        var col = digit1 + digit3;
        var sum = n;
        for (int i = 1; i <= row; i++)
        {
            for (int j  = 1; j <= col; j++)
            {
                if (sum % 5==0)
                {
                    sum -=digit1;
                }
                else if (sum % 3 ==0)
                {
                    sum -= digit2;
                }
                else
                {
                    sum += digit3;
                }
                Console.Write("{0} ", sum);
            }
            Console.WriteLine();
        }        
    }
}

