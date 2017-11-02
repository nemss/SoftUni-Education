using System;

class TradeComissions
{
    static void Main()
    {
        var town = Console.ReadLine().ToLower();
        var sales = double.Parse(Console.ReadLine());
        double comission = -1;

        if (town =="sofia")
        {
            if (sales>=0 && sales<=500)
            {
                comission = 0.05;
            }
            else if (sales >500 && sales<=1000)
            {
                comission = 0.07;
            }
            else if (sales > 1000 && sales <= 10000)
            {
                comission = 0.08;
            }
            else if (sales > 10000)
            {
                comission = 0.12;
            }


        }
        else if (town=="varna")
        {
            if (sales >= 0 && sales <= 500)
            {
                comission = 0.045;
            }
            else if (sales > 500 && sales <= 1000)
            {
                comission = 0.075;
            }
            else if (sales > 1000 && sales <= 10000)
            {
                comission = 0.10;
            }
            else if (sales > 10000)
            {
                comission = 0.13;
            }

        }
        else if (town=="plovdiv")
        {
            if (sales >= 0 && sales <= 500)
            {
                comission = 0.055;
            }
            else if (sales > 500 && sales <= 1000)
            {
                comission = 0.08;
            }
            else if (sales > 1000 && sales <= 10000)
            {
                comission = 0.12;
            }
            else if (sales > 10000)
            {
                comission = 0.145;
            }

        }
        if (comission>0)
        {
            Console.WriteLine(comission*sales);
        }
        else
        {
            Console.WriteLine("error");
        }
    }
}

