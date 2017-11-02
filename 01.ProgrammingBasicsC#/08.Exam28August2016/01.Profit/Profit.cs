using System;

class Profit
{
    static void Main()
    {
        var dayWorkInMonth = int.Parse(Console.ReadLine());
        var profitMoneyPerDay = double.Parse(Console.ReadLine());
        var rateDollar = double.Parse(Console.ReadLine());

        var moneyForMonth = dayWorkInMonth * profitMoneyPerDay;
        var yearMoney = moneyForMonth * 12 + moneyForMonth * 2.5;
        var tax = yearMoney * 25 / 100;
        var allMoney = yearMoney - tax;
        var allMoneyInLeva = allMoney * rateDollar;
        var middleProfit = allMoneyInLeva / 365;
        Console.WriteLine("{0:f2}", middleProfit);
    }
}

