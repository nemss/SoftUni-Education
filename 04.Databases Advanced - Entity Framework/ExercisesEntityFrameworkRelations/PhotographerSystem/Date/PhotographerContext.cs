namespace PhotographerSystem
{
    using Migrations;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PhotographerContext : DbContext
    {

        public PhotographerContext()
            : base("name=PhotographerContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PhotographerContext, Configuration>());
        }
        public virtual IDbSet<Photographer> Photographers { get; set; }

        public virtual IDbSet<Album> Albums { get; set; }

        public virtual IDbSet<Picture> Pictures { get; set; }

        public virtual IDbSet<Tag> Tags { get; set; }


    }

}