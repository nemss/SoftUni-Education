namespace News.Services.Implementations
{
    using Data;
    using Interfaces;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class NewsController : INewsService
    {
        private readonly NewsDbContext db;

        public NewsController(NewsDbContext db)
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

        public Task<bool> Edit(int id, string title, string content, DateTime publishDate)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
