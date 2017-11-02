using System.Collections.Generic;

public class ItemCommand : AbstractCommand
{
    public ItemCommand(IList<string> args, IHeroManager heroManager)
        : base(args, heroManager)
    {
    }

    public override string Excute()
    {
        return this.HeroManager.AddItemToHero(this.Args);
    }
}