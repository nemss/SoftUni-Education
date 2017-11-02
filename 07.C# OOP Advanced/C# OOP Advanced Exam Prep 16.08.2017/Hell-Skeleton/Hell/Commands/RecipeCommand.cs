using System.Collections.Generic;

public class RecipeCommand : AbstractCommand
{
    public RecipeCommand(IList<string> args, IHeroManager heroManager)
        : base(args, heroManager)
    {
    }

    public override string Excute()
    {
        return this.HeroManager.AddRecipeToHero(this.Args);
    }
}