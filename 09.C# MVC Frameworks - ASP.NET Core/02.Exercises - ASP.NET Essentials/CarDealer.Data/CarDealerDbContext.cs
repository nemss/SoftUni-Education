namespace CarDealer.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class CarDealerDbContext : IdentityDbContext<User>
    {
        public DbSet<Car> Cars { get; set; }

        public DbSet<Part> Parts { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public CarDealerDbContext(DbContextOptions<CarDealerDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder
                .Entity<PartCar>()
                .HasKey(pc => new { pc.CarId, pc.PartId });

            builder
                .Entity<Car>()
                .HasMany(c => c.Parts)
                .WithOne(p => p.Car)
                .HasForeignKey(c => c.CarId);

            builder
                .Entity<Part>()
                .HasMany(p => p.Cars)
                .WithOne(c => c.Part)
                .HasForeignKey(p => p.PartId);

            builder
                .Entity<Supplier>()
                .HasMany(s => s.Parts)
                .WithOne(p => p.Supplier)
                .HasForeignKey(s => s.SupplierId);

            builder
                .Entity<Sale>()
                .HasOne(s => s.Car)
                .WithMany(c => c.Sales)
                .HasForeignKey(s => s.CarId);

            builder
                .Entity<Sale>()
                .HasOne(s => s.Customer)
                .WithMany(c => c.Sales)
                .HasForeignKey(s => s.CustomerId);

            base.OnModelCreating(builder);
        }
    }
}
