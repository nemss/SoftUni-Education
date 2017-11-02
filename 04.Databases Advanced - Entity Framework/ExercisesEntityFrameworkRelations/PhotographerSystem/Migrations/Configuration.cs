namespace PhotographerSystem.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PhotographerSystem.PhotographerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PhotographerSystem.PhotographerContext context)
        {
            Photographer pesho = new Photographer()
            {
                Username = "Pesho",
                Password = "sdwsfwd",
                Email = "pesho@pesho.com",
                RegisterDate = DateTime.Now,
                Birthday = new DateTime(2001, 01, 02),
            };

            context.Photographers.AddOrUpdate(p => p.Username, pesho);
            context.SaveChanges();

            Picture picture = new Picture()
            {
                Title = "demo",
                Caption = "demo",
                FileSystemPath = "c::"
            };

            context.Pictures.AddOrUpdate(p => p.Title ,picture);

            Album plovdiv = new Album()
            {
                Name = "Plovdiv",
                BackgroundColor = "Blue",
                IsPublic = true,
            };
            plovdiv.Photographers.Add(pesho);

            context.Albums.AddOrUpdate(a => a.Name, plovdiv);
            plovdiv.Pictures.Add(picture);

            Tag town = new Tag()
            {
                Name = "#town"
            };

            context.Tags.AddOrUpdate(t => t.Name ,town);
            town.Albums.Add(plovdiv);
            context.SaveChanges();
        }
    }
}
