namespace ProductsShop.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using ProductsShop.Model;
    using System.Collections.Generic;

    public class ProductShopContext : DbContext
    {
        public ProductShopContext()
            : base("name=ProductShopContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(user => user.MyFriends)
                .WithMany(user => user.FriendsWithMe)
                .Map(config =>
                {
                    config.MapLeftKey("UserId");
                    config.MapRightKey("FriendId");
                    config.ToTable("UserFriends");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}