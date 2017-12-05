namespace BookShop.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Common.Extensions;
    using Data;
    using Data.Models;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Models.Book;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class BookService : IBookService
    {
        private readonly BookShopDbContext db;

        public BookService(BookShopDbContext db)
        {
            this.db = db;
        }

        public async Task<int> Create(
            string title,
            string description,
            decimal price,
            int copies,
            int? edition,
            int? ageRestriction,
            DateTime releaseDate,
            int authorId,
            string categories)
        {
            var categoryNames = categories.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToHashSet();

            var existingCategories = await this.db
                .Categories
                .Where(c => categoryNames.Contains(c.Name))
                .ToListAsync();

            var allCategories = new List<Category>(existingCategories);

            foreach (var categoryName in categoryNames)
            {
                if (existingCategories.All(c => c.Name != categoryName))
                {
                    var category = new Category
                    {
                        Name = categoryName
                    };

                    this.db.Add(category);

                    allCategories.Add(category);
                }
            }

            var book = new Book
            {
                Title = title,
                Description = description,
                Price = price,
                Copies = copies,
                Edition = edition,
                AgeRestriction = ageRestriction,
                ReleaseDate = releaseDate,
                AuthorId = authorId
            };

            allCategories.ForEach(c => book.Categories.Add(new BookCategory
            {
                CategoryId = c.Id
            }));

            this.db.Add(book);
            await this.db.SaveChangesAsync();

            return book.Id;
        }

        public async Task<IEnumerable<BookListingServiceModel>> All(string search)
            => await this.db
                .Books
                .Where(b => b.Title.ToLower().Contains(search.ToLower()))
                .OrderBy(b => b.Title)
                .Take(10)
                .ProjectTo<BookListingServiceModel>()
                .ToListAsync();

        public async Task<BookDetailsServiceModel> Details(int id)
            => await this.db
                .Books
                .Where(b => b.Id == id)
                .ProjectTo<BookDetailsServiceModel>()
                .FirstOrDefaultAsync();
    }
}