using System.Collections.Generic;

public class HeroCommand : AbstractCommand
{
    public HeroCommand(IList<string> args, IHeroManager heroManager)
        : base(args, heroManager)
    {
    }

    public override string Excute()
    {
        return this.HeroManager.AddHero(this.Args);
    }
}