namespace BookShop.Services.Implementations
{
    using Data;
    using Interfaces;
    using Models.Author;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class AuthorService : IAuthorService
    {
        private readonly BookShopDbContext db;

        public AuthorService(BookShopDbContext db)
        {
            this.db = db;
        }

        public async Task<int> Create(string firstName, string lastName)
        {
            var author = new Author
            {
                FirstName = firstName,
                LastName = lastName
            };

             this.db.Add(author);
             await this.db.SaveChangesAsync();

            return author.Id;
        }

        public async Task<AuthorDetailsServiceModel> Details(int id)
            => await this.db
                .Authors
                .Where(a => a.Id == id)
                .ProjectTo<AuthorDetailsServiceModel>()
                .FirstOrDefaultAsync();
    }
}
