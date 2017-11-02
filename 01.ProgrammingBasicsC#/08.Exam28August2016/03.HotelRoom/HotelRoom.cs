using System;

class HotelRoom
{
    static void Main()
    {
        var month = Console.ReadLine().ToLower();
        var nights = int.Parse(Console.ReadLine());
        var apartament = 0.0;
        var studio = 0.0;

        if (month=="may" || month=="october")
        {
            if (7<nights && nights <14) 
            {
                studio =50-(50 * 0.05);
                apartament = 65.00;
            }
            else if (14<nights)
            {
                studio = 50 - (50 * 0.3);
                apartament = 65.00 - (65.00 * 0.1);
            }
            else if (nights<=7)
            {
                studio = 50;
                apartament = 65.00;
            }
        }
        else if (month=="june" || month=="september")
        {
            if (14<nights)
            {
                studio = 75.20 - (75.20 * 0.2);
                apartament = 68.70 - (68.70 * 0.1);
            }
            else
            {
                studio = 75.20;
                apartament = 68.70;
            }
        }
        else if (month=="july" || month=="august")
        {
            if (14<nights)
            {
                studio = 76;
                apartament = 77 - (77 * 0.1);
            }
            else
            {
                studio = 76;
                apartament = 77;
            }
        }
        var totalPriceStudio = studio * nights;
        var totalPriceApartament = apartament * nights;
        Console.WriteLine("Apartment: {0:f2} lv.", totalPriceApartament);
        Console.WriteLine("Studio: {0:f2} lv.", totalPriceStudio);
    }
}

