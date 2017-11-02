using System;

class Money
{
    static void Main()
    {
        var bitcoins = int.Parse(Console.ReadLine());
        var iuan = double.Parse(Console.ReadLine());
        var commision = double.Parse(Console.ReadLine());

        var bitcoinInLeva = bitcoins * 1168;
        var iuanInDollar = iuan * 0.15;
        var iuanInLeva = iuanInDollar * 1.76;
        var moneyInEuro = (bitcoinInLeva + iuanInLeva) / 1.95;
        var commisionFromEuro = (commision*moneyInEuro)/100;
        var sum = ( moneyInEuro - commisionFromEuro);
        Console.WriteLine(sum);
    }
}

