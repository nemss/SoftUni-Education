namespace Library.Data.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LibraryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Library.Data.LibraryContext";
        }

        protected override void Seed(LibraryContext context)
        {

            User admin = new User()
            {
                FirstName = "Administrator",
                LastName = "Administrator",
                Age = 20,
                Role = 0,
                RegisteredOn = DateTime.Now,
                Genre = 0,
                Email = "libraryAdministratory@gmail.com",
                Password = "admin123",
                Username = "admin"
            };

            context.Users.AddOrUpdate(p => p.Username, admin);
            context.SaveChanges();

        }
    }
}
