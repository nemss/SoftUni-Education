namespace _5.PizzaCalories
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            try
            {
                string inputLine;
                while (!(inputLine = Console.ReadLine()).Equals("END"))
                {
                    var tokens = inputLine.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                    if (tokens[0].Equals("Dough"))
                    {
                        var dough = new Dough(tokens[1], tokens[2], int.Parse(tokens[3]));
                        Console.WriteLine($"{dough.Calories():f2}");
                    }
                    else if(tokens[0].Equals("Topping"))
                    {
                        var topping = new Topping(tokens[1], int.Parse(tokens[2]));
                        Console.WriteLine($"{topping.Callories():f2}");
                    }
                    else
                    {
                        var pizzaName = tokens[1];
                        var numberOfToppings = int.Parse(tokens[2]);
                        if (numberOfToppings > 10)
                        {
                            Console.WriteLine("Number of toppings should be in range [0..10].");
                            return;
                        }

                        inputLine = Console.ReadLine();
                        var tokensDough = inputLine.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                        var dough = new Dough(tokensDough[1], tokensDough[2], int.Parse(tokensDough[3]));
                        var pizza = new Pizza(pizzaName, dough);

                        for (int i = 0; i < numberOfToppings; i++)
                        {
                            inputLine = Console.ReadLine();
                            var tokenTopping = inputLine.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                            pizza.AddToppind(new Topping(tokenTopping[1], int.Parse(tokenTopping[2])));
                        }

                        Console.WriteLine($"{pizza.Name} - {pizza.Callories():f2} Calories.");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }  
}
