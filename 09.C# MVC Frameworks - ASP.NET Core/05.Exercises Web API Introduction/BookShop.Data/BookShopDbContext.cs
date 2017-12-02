namespace BookShop.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class BookShopDbContext : DbContext
    {
        public BookShopDbContext(DbContextOptions<BookShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<BookCategory> BooksInCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<BookCategory>()
                .HasKey(bc => new { bc.BookId, bc.CategoryId });

            builder
                .Entity<Book>()
                .HasMany(a => a.Categories)
                .WithOne(bc => bc.Book)
                .HasForeignKey(bc => bc.BookId);

            builder
                .Entity<Category>()
                .HasMany(c => c.Books)
                .WithOne(bc => bc.Category)
                .HasForeignKey(bc => bc.CategoryId);

            builder
                .Entity<Author>()
                .HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId);

            base.OnModelCreating(builder);
        }
    }
}
