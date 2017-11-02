namespace GringottsDatabase
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using GringottsDatabase.Models;
    using System.Data.Entity.Infrastructure;

    public class GringottsContext : DbContext
    {
        public GringottsContext()
            : base("name=GringottsContext")
        {
        }
        public virtual IDbSet<WizardDeposit> WizardeDposits { get; set; }
    }
}