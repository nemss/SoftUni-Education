using System;

class Trip
{
    static void Main()
    {
        var money = double.Parse(Console.ReadLine());
        var season = Console.ReadLine().ToLower();

        if (money<=100)
        {
            if (season=="summer")
            {
                money = money * 0.30;
                Console.WriteLine("Somewhere in Bulgaria");
                Console.WriteLine("Camp - {0:f2}", money);
            }
            else if (season=="winter")
            {
                money = money * 0.70;
                Console.WriteLine("Somewhere in Bulgaria");
                Console.WriteLine("Hotel - {0:f2}", money);
            }
         
        }
        else if (money>100 && money<=1000)
        {
            if (season == "summer")
            {
                money = money * 0.40;
                Console.WriteLine("Somewhere in Balkans");
                Console.WriteLine("Camp - {0:f2}", money);
            }
            else if (season == "winter")
            {
                money = money * 0.80;
                Console.WriteLine("Somewhere in Balkans");
                Console.WriteLine("Hotel - {0:f2}", money);
            }
        }
        else if (money>1000)
        {
            money = money * 0.90;
            Console.WriteLine("Somewhere in Europe");
            Console.WriteLine("Hotel - {0:f2}", money);

        }

    }
}

