public class Barbarian : AbstractHero
{
    private const int StrengthPointsDefault = 90;
    private const int AgilityPointsDefault = 25;
    private const int IntelligencePointsDefault = 10;
    private const int HitPointsDefault = 350;
    private const int DamagePointDefault = 150;

    public Barbarian(string name)
        : base(name,
            StrengthPointsDefault,
            AgilityPointsDefault,
            IntelligencePointsDefault,
            HitPointsDefault,
            DamagePointDefault)
    {
    }
}