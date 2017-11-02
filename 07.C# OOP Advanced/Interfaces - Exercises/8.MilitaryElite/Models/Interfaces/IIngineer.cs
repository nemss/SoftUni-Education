namespace _8.MilitaryElite.Models.Interfaces
{
    using System.Collections.Generic;

    public interface IIngineer
    {
        ICollection<IRepair> Repairs { get; }
    }
}