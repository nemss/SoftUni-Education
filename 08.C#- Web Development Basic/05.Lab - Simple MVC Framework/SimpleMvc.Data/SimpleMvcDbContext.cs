namespace SimpleMvc.Data
{
    using Domain;
    using Microsoft.EntityFrameworkCore;

    public class SimpleMvcDbContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder
                .UseSqlServer("Server=.;Database=SimpleMvc;Integrated Security=True");

            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<User>()
                .HasMany(u => u.Notes)
                .WithOne(n => n.User)
                .HasForeignKey(n => n.UserId);

            base.OnModelCreating(builder);
        }
    }
}