namespace SimpleMapping.Data.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SimpleMapping.Data.SimpleMappingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SimpleMappingContext>());
            ContextKey = "SimpleMapping.Data.SimpleMappingContext";
        }

        protected override void Seed(SimpleMapping.Data.SimpleMappingContext context)
        {
            Employee employeePesho = new Employee()
            {
                FirstName = "Pesho",
                LastName = "Pesho",
                Salary = 10000,
                Birthday = DateTime.Now,
                Address = "Ivan vazov"
            };

            Employee employeeGosho = new Employee()
            {
                FirstName = "Gosho",
                LastName = "Gosho",
                Salary = 10000,
                Birthday = DateTime.Now,
                Address = "Pamir"
            };

            context.Employees.AddOrUpdate(x => x.FirstName, employeePesho, employeeGosho);

        }
    }
}
