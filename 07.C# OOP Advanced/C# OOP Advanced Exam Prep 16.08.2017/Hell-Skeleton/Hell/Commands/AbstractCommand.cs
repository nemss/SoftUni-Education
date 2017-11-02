using System.Collections.Generic;

public abstract class AbstractCommand : ICommand
{
    private IList<string> args;
    private IHeroManager heroManager;

    protected AbstractCommand(IList<string> args, IHeroManager heroManager)
    {
        this.Args = args;
        this.HeroManager = heroManager;
    }

    public IList<string> Args
    {
        get { return this.args; }
        set { this.args = value; }
    }

    public IHeroManager HeroManager
    {
        get { return this.heroManager; }
        set { this.heroManager = value; }
    }

    public abstract string Excute();
}