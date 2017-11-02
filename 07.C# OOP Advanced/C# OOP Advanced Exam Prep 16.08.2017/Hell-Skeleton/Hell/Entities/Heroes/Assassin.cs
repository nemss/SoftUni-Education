public class Assassin : AbstractHero
{
    private const int StrengthPointsDefault = 25;
    private const int AgilityPointsDefault = 100;
    private const int IntelligencePointsDefault = 15;
    private const int HitPointsDefault = 150;
    private const int DamagePointDefault = 300;

    public Assassin(string name)
        : base(name,
            StrengthPointsDefault,
            AgilityPointsDefault,
            IntelligencePointsDefault,
            HitPointsDefault,
            DamagePointDefault)
    {
    }
}