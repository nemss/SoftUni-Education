using System;

class Trip
{
    static void Main()
    {
        var biudget = double.Parse(Console.ReadLine());
        var season = Console.ReadLine().ToLower();

        if (100>=biudget)
        {
            Console.WriteLine("Somewhere in Bulgaria");
            if (season=="summer")
            {
                Console.WriteLine("Camp - {0:f2}", biudget*0.3);
            }
            else
            {
                Console.WriteLine("Hotel - {0:f2}", biudget*0.7);
            }
        }
        else if (biudget<=1000 && biudget>100)
        {
            Console.WriteLine("Somewhere in Balkans");
            if (season == "summer")
            {
                Console.WriteLine("Camp - {0:f2}", biudget * 0.4);
            }
            else
            {
                Console.WriteLine("Hotel - {0:f2}", biudget * 0.8);
            }
        }
        else if (biudget>1000)
        {
            Console.WriteLine("Somewhere in Europe");
            Console.WriteLine("Hotel - {0:f2}", biudget*0.9);
        }
    }
}

