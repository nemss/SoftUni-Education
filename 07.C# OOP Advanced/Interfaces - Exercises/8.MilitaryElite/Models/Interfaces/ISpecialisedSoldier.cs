namespace _8.MilitaryElite.Models.Interfaces
{
    using _8.MilitaryElite.Enum;

    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corps { get; }
    }
}