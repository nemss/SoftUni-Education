namespace _8.MilitaryElite.Models
{
    using _8.MilitaryElite.Enum;
    using _8.MilitaryElite.Models.Interfaces;

    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(string id, string firstName, string lastName, double salary, Corps corps)
            : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public Corps Corps { get; }
    }
}