using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var n = double.Parse(Console.ReadLine());
        var oddMinNumber = double.MaxValue;
        var oddMaxNumber = double.MinValue;
        double oddSum = 0.0;

        var EvenMaxNumber = double.MinValue;
        var EvenMinNumber = double.MaxValue;
        double evenSum = 0.0;

        for (int i = 1; i <= n; i++)
        {
            var numbers = double.Parse(Console.ReadLine());

            if (i%2==0)
            {
                if (numbers>EvenMaxNumber)
                {
                    EvenMaxNumber = numbers;
                }
                if (numbers<EvenMinNumber)
                {
                    EvenMinNumber = numbers;
                }
                evenSum += numbers;
            }
            else
            {
                if (numbers>oddMaxNumber)
                {
                    oddMaxNumber = numbers;
                }
                if (numbers<oddMinNumber)
                {
                    oddMinNumber = numbers;
                }
                oddSum += numbers;
            }

        }
        Console.WriteLine("OddSum={0}", oddSum);


        if (oddMinNumber == double.MaxValue)
        {

            Console.WriteLine("OddMin=No");
        }
        else
        {
            Console.WriteLine("OddMin={0}", oddMinNumber);
        }

        if (oddMaxNumber == double.MinValue)
        {

            Console.WriteLine("OddMax=No");
        }
        else
        {
            Console.WriteLine("OddMax={0}", oddMaxNumber);
        }
        Console.WriteLine("EvenSum={0}", evenSum);

        if (EvenMinNumber == double.MaxValue)
        {

            Console.WriteLine("EvenMin=No");
        }
        else
        {
            Console.WriteLine("EvenMin={0}", EvenMinNumber);
        }

        if (EvenMaxNumber == double.MinValue)
        {

            Console.WriteLine("EvenMax=No");
        }
        else
        {
            Console.WriteLine("EvenMax={0}", EvenMaxNumber);
        }
    }
}

