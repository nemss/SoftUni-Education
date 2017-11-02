using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class HeroManager : IHeroManager
{
    private Dictionary<string, IHero> heroes;
    private IItemFactory itemFactory;
    private IRecipeFactory recipeFactory;

    public HeroManager(IItemFactory itemFactory, IRecipeFactory recipeFactory)
    {
        this.itemFactory = itemFactory;
        this.recipeFactory = recipeFactory;
        this.heroes = new Dictionary<string, IHero>();
    }

    public string AddHero(IList<String> arguments)
    {
        string result = string.Empty;

        string heroName = arguments[0];
        string heroType = arguments[1];

        try
        {
            var getTypeHero = Type.GetType(heroType);
            var hero = (AbstractHero)Activator.CreateInstance(getTypeHero, heroName);
            this.heroes[heroName] = hero;

            result = string.Format(Constants.HeroCreateMessage, heroType, hero.Name);
        }
        catch (Exception e)
        {
            return e.Message;
        }

        return result;
    }

    public string AddItemToHero(IList<String> arguments)
    {
        string result = string.Empty;
        var heroName = arguments[1];

        var createNewItem = itemFactory.Crete(arguments);
        heroes[heroName].AddItem(createNewItem);

        result = string.Format(Constants.ItemCreateMessage, createNewItem.Name, heroName);

        return result;
    }

    public string AddRecipeToHero(IList<string> arguments)
    {
        var heroName = arguments[1];
        var recipe = recipeFactory.Create(arguments);

        this.heroes[heroName].AddRecipe(recipe);

        return string.Format(Constants.RecipeCreatedMessage, recipe.Name, heroName);
    }

    public string Quit()
    {
        var sb = new StringBuilder();

        int counter = 1;

        var orderedHeroes = this.heroes
            .OrderByDescending(h => h.Value.PrimaryStats)
            .ThenByDescending(h => h.Value.SecondaryStats)
            .ToDictionary(x => x.Key, y => y.Value);

        foreach (var hero in orderedHeroes)
        {
            sb.AppendLine($"{counter++}. {hero.Value.GetType().Name}: {hero.Key}");
            sb.AppendLine($"###HitPoints: {hero.Value.HitPoints}");
            sb.AppendLine($"###Damage: {hero.Value.Damage}");
            sb.AppendLine($"###Strength: {hero.Value.Strength}");
            sb.AppendLine($"###Agility: {hero.Value.Agility}");
            sb.AppendLine($"###Intelligence: {hero.Value.Intelligence}");

            if (hero.Value.Items.Count == 0)
            {
                sb.AppendLine($"###Items: None");
            }
            else
            {
                sb.Append($"###Items: ");
                var items = hero.Value.Items.Select(i => i.Name).ToList();
                sb.AppendLine(string.Join(", ", items));
            }
        }

        return sb.ToString().Trim();
    }

    public string Inspect(IList<String> arguments)
    {
        string heroName = arguments[0];

        return this.heroes[heroName].ToString();
    }
}