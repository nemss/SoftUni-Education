namespace Projection.Data.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Projection.Data.ProjectionContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ProjectionContext>());
            ContextKey = "Projection.Data.ProjectionContext";
        }

        protected override void Seed(Projection.Data.ProjectionContext context)
        {
            Employee manager = new Employee()
            {
                FirstName = "Pesho",
                LastName = "Pesho",
                Salary = 10000,
                Birthday = DateTime.Now,
                Address = "Ivan vazov",
                Manager = new Employee() { FirstName = "Petkan", LastName = "Petkanov" },
            };

            Employee employee1 = new Employee()
            {
                FirstName = "Gosho",
                LastName = "Gosho",
                Salary = 14440,
                Birthday = DateTime.Now,
                Address = "Ivan vazov",
                Manager = manager
            };


            Employee employee2 = new Employee()
            {
                FirstName = "Valentin",
                LastName = "Valentinov",
                Salary = 1455440,
                Birthday = DateTime.Now,
                Address = "Ivan vazov",
                Manager = manager
            };


            Employee employee3 = new Employee()
            {
                FirstName = "Gosho",
                LastName = "Pesho",
                Salary = 140,
                Birthday = DateTime.Now,
                Address = "Ivan vazov",
                Manager = manager
            };

            context.Employees.AddOrUpdate(employee1, employee2, employee3, manager);
            context.SaveChanges();
        }
    }
}
