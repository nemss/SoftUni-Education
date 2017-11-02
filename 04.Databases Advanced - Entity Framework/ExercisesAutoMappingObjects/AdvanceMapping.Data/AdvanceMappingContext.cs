namespace AdvanceMapping.Data
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class AdvanceMappingContext : DbContext
    {
        
        public AdvanceMappingContext()
            : base("name=AdvanceMappingContext")
        {
        }

        public virtual IDbSet<Employee> Employees { get; set; }
    }
}