using System;
using System.Collections;
using System.Collections.Generic;

public class CoffeeMachine : IEnumerable<CoffeeType>
{
    public CoffeeMachine()
    {
        this.CoffeesSold = new List<CoffeeType>();
    }

    private int coin;
    public List<CoffeeType> CoffeesSold { get; }

    public void BuyCoffee(string size, string type)
    {
        CoffeeType coffeType = (CoffeeType)Enum.Parse(typeof(CoffeeType), type);
        CoffeePrice coffeePrice = (CoffeePrice)Enum.Parse(typeof(CoffeePrice), size);

        if (this.coin >= (int)coffeePrice)
        {
            this.CoffeesSold.Add(coffeType);
            this.coin = 0;
        }
    }

    public void InsertCoin(string coin)
    {
        Coin insertCoin = (Coin)Enum.Parse(typeof(Coin), coin);
        this.coin += (int)insertCoin;
    }

    public IEnumerator<CoffeeType> GetEnumerator()
    {
        return this.CoffeesSold.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}