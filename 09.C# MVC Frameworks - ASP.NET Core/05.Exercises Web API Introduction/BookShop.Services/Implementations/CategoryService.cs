namespace BookShop.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Models.Category;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CategoryService : ICategoryService
    {
        private readonly BookShopDbContext db;

        public CategoryService(BookShopDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<CategoryServiceModel>> All()
            => await this.db
                .Categories
                .ProjectTo<CategoryServiceModel>()
                .ToListAsync();

        public async Task<int> Create(string name)
        {
            var category = new Category
            {
                Name = name
            };

            this.db.Add(category);
            await this.db.SaveChangesAsync();

            return category.Id;
        }

        public async Task<bool> Exists(string name)
            => await this.db.Categories.AnyAsync(c => c.Name == name);

        public async Task<CategoryServiceModel> FindById(int id)
            => await this.db
                .Categories
                .Where(c => c.Id == id)
                .ProjectTo<CategoryServiceModel>()
                .FirstOrDefaultAsync();

        public async Task<int> Delete(int id)
        {
            var categoryFindById = await this.db
                .Categories
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

            this.db.Remove(categoryFindById);
            await this.db.SaveChangesAsync();

            return categoryFindById.Id;
        }

        public async Task<bool> Edit(int id, string name)
        {
            if (await this.Exists(name))
            {
                return false;
            }

            var category = await this.db
                .Categories
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

            if (category == null)
            {
                return false;
            }

            category.Name = name;
            await this.db.SaveChangesAsync();

            return true;
        }
    }
}