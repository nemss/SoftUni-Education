using System;

class Sums3Numbers
{
    static void Main()
    {
        var firstNumber = int.Parse(Console.ReadLine());
        var secondNumber = int.Parse(Console.ReadLine());
        var thirdNumber = int.Parse(Console.ReadLine());

        var max = Math.Max(firstNumber, secondNumber);
        var max2 = Math.Max(firstNumber, thirdNumber);
        var max3 = Math.Max(secondNumber, thirdNumber);

        if (firstNumber+secondNumber==thirdNumber && firstNumber<=secondNumber)
        {
            Console.WriteLine("{0} + {1} = {2}", firstNumber, secondNumber, thirdNumber);
        }
        else if (firstNumber + secondNumber == thirdNumber && firstNumber >= secondNumber)
        {
            Console.WriteLine("{0} + {1} = {2}", secondNumber,firstNumber, thirdNumber);
        }
        else if (thirdNumber + secondNumber == firstNumber && thirdNumber <= secondNumber)
        {
            Console.WriteLine("{0} + {1} = {2}", thirdNumber, secondNumber, firstNumber);
        }
        else if (thirdNumber + secondNumber == firstNumber && thirdNumber >= secondNumber)
        {
            Console.WriteLine("{0} + {1} = {2}", secondNumber,thirdNumber, firstNumber);
        }
        else if (thirdNumber + firstNumber == secondNumber && thirdNumber <= firstNumber)
        {
            Console.WriteLine("{0} + {1} = {2}", thirdNumber, firstNumber, secondNumber);
        }
        else if (thirdNumber + firstNumber == secondNumber && thirdNumber >= firstNumber)
        {
            Console.WriteLine("{0} + {1} = {2}", firstNumber,thirdNumber, secondNumber);
        }
        else
        {
            Console.WriteLine("No");
        }
    }
}

