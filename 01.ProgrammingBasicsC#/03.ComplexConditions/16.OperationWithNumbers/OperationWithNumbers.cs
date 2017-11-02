using System;

class OperationWithNumbers
{
    static void Main()
    {
        var number1 = double.Parse(Console.ReadLine());
        var number2 = double.Parse(Console.ReadLine());
        var symbol = char.Parse(Console.ReadLine());
        var sum = 0.0;


        if (symbol=='+')
        {
            sum = number1 + number2;
            if (sum %2==0)
            {
                Console.WriteLine("{0} {1} {2} = {3} - even",number1, symbol, number2, sum);
            }
            else
            {
                Console.WriteLine("{0} {1} {2} = {3} - odd", number1, symbol, number2, sum);
            }
        }
        else if (symbol=='-')
        {
            sum = number1 - number2;
            if (sum % 2 == 0)
            {
                Console.WriteLine("{0} {1} {2} = {3} - even", number1, symbol, number2, sum);
            }
            else
            {
                Console.WriteLine("{0} {1} {2} = {3} - odd", number1, symbol, number2, sum);
            }
        }
        else if (symbol == '*' )
        {
            sum = number1 * number2;
            if (sum % 2 == 0)
            {
                Console.WriteLine("{0} {1} {2} = {3} - even", number1, symbol, number2, sum);
            }
            else
            {
                Console.WriteLine("{0} {1} {2} = {3} - odd", number1, symbol, number2, sum);
            }
        }
        else if (symbol=='/' && number2 !=0)
        {
            sum =(number1/number2);
            Console.WriteLine("{0} {1} {2} = {3:F2}", number1, symbol, number2,sum);
            
        }
        else if (symbol=='%' && number2 != 0)
        {
            sum = number1 % number2;
            Console.WriteLine("{0} % {1} = {2}", number1, number2, sum);
        }
        else if (number2==0)
        {
            Console.WriteLine("Cannot divide {0} by zero", number1);
        }
       

    }
}

