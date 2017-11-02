using System.Collections.Generic;

public interface IRecipeFactory
{
    IRecipe Create(IList<string> args);
}