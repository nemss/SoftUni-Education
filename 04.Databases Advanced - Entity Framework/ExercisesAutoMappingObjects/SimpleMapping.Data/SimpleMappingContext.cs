namespace SimpleMapping.Data
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SimpleMappingContext : DbContext
    {
        public SimpleMappingContext()
            : base("name=SimpleMappingContext")
        {
        }

        public virtual IDbSet<Employee> Employees { get; set; }
    }
}