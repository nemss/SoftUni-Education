using System;

class MatchTickets
{
    static void Main()
    {
        var biudget = double.Parse(Console.ReadLine());
        var category = Console.ReadLine().ToLower();
        var people = int.Parse(Console.ReadLine());
        var categoryPrice = category == "vip" ? 499.99 : 249.99;
        var biudgetForTransport = 1.0;
        var sumLeft = 0.0;
        var ticketPrice = 1.0;

        if (1<=people && people<=4)
        {
            biudgetForTransport = 0.75 * biudget;
            sumLeft = biudget - biudgetForTransport;
            ticketPrice = categoryPrice * people;
        }
        else if (5<=people && people<=9)
        {
            biudgetForTransport = 0.6 * biudget;
            sumLeft = biudget - biudgetForTransport;
            ticketPrice = categoryPrice * people;
        }
        else if (10 <= people && people <= 24)
        {
            biudgetForTransport = 0.5 * biudget;
            sumLeft = biudget - biudgetForTransport;
            ticketPrice = categoryPrice * people;
        }
        else if (25 <= people && people <= 49)
        {
            biudgetForTransport = 0.4 * biudget;
            sumLeft = biudget - biudgetForTransport;
            ticketPrice = categoryPrice * people;
        }
        else if (50 <= people)
        {
            biudgetForTransport = 0.25 * biudget;
            sumLeft = biudget - biudgetForTransport;
            ticketPrice = categoryPrice * people;
        }
        if (ticketPrice<sumLeft)
        {
            Console.WriteLine("Yes! You have {0:f2} leva left.", sumLeft-ticketPrice);
        }
        else
        {
            Console.WriteLine("Not enough money! You need {0:f2} leva.", ticketPrice-sumLeft);
        }
    }
}

