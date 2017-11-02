using System.Collections.Generic;

public class InspectCommand : AbstractCommand
{
    public InspectCommand(IList<string> args, IHeroManager heroManager)
        : base(args, heroManager)
    {
    }

    public override string Excute()
    {
        return this.HeroManager.Inspect(this.Args);
    }
}