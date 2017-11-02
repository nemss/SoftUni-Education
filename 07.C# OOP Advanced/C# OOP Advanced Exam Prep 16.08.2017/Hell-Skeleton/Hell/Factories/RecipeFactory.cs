using System;
using System.Collections.Generic;
using System.Linq;

public class RecipeFactory : IRecipeFactory
{
    public IRecipe Create(IList<string> arguments)
    {
        var recipeName = arguments[0];
        int strengthBonus = int.Parse(arguments[2]);
        int agilityBonus = int.Parse(arguments[3]);
        int intelligenceBonus = int.Parse(arguments[4]);
        int hitPointsBonus = int.Parse(arguments[5]);
        int damageBonus = int.Parse(arguments[6]);
        var neededItems = arguments.Skip(7).ToList();

        var data = new object[]
        {
            recipeName,
            strengthBonus,
            agilityBonus,
            intelligenceBonus,
            hitPointsBonus,
            damageBonus,
            neededItems
        };

        var getTypeRecipe = typeof(RecipeItem);

        var createInstanceRecipe = (IRecipe)Activator.CreateInstance(getTypeRecipe, data);

        return createInstanceRecipe;
    }
}