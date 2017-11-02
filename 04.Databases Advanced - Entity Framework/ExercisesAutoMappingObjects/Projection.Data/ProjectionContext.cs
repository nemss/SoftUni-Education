namespace Projection.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Projection.Models;

    public class ProjectionContext : DbContext
    {
        
        public ProjectionContext()
            : base("name=ProjectionContext")
        {
        }

        public virtual IDbSet<Employee> Employees { get; set; }
    }
}