public class Wizard : AbstractHero
{
    private const int StrengthPointsDefault = 25;
    private const int AgilityPointsDefault = 25;
    private const int IntelligencePointsDefault = 100;
    private const int HitPointsDefault = 100;
    private const int DamagePointDefault = 250;

    public Wizard(string name)
        : base(name,
            StrengthPointsDefault,
            AgilityPointsDefault,
            IntelligencePointsDefault,
            HitPointsDefault,
            DamagePointDefault)
    {
    }
}