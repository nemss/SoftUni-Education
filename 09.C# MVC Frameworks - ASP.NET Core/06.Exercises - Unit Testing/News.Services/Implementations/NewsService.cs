namespace News.Services.Implementations
{
    using Data;
    using Data.Models;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class NewsService : INewsService
    {
        private readonly NewsDbContext db;

        public NewsService(NewsDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<NewsListingServiceModel>> All()
            => await this.db
                .News
                .Select(n => new NewsListingServiceModel
                {
                    Id = n.Id,
                    Title = n.Title,
                    Content = n.Content,
                    PublishDate = n.PublishDate
                })
                .ToListAsync();

        public async Task<int> Create(string title, string content, DateTime publishDate)
        {
            var news = new News
            {
                Title = title,
                Content = content,
                PublishDate = publishDate
            };

            this.db.Add(news);
            await this.db.SaveChangesAsync();

            return news.Id;
        }

        public async Task<bool> Edit(int id, string title, string content, DateTime publishDate)
        {
            var news = await this.db
                .News
                .Where(n => n.Id == id)
                .FirstOrDefaultAsync();

            if (news == null)
            {
                return false;
            }

            news.Content = content;
            news.Title = title;
            news.PublishDate = publishDate;

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<int> Delete(int id)
        {
            var newsFindById = await this.db
                .News
                .Where(n => n.Id == id)
                .FirstOrDefaultAsync();

            this.db.Remove(newsFindById);
            await this.db.SaveChangesAsync();

            return newsFindById.Id;
        }

        public async Task<NewsListingServiceModel> FindById(int id)
            => await this.db
                .News
                .Where(c => c.Id == id)
                .Select(n => new NewsListingServiceModel
                {
                    Id = n.Id,
                    Title = n.Title,
                    Content = n.Content,
                    PublishDate = n.PublishDate
                })
                .FirstOrDefaultAsync();
    }
}
