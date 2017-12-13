namespace News.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public interface INewsService
    {
        Task<IEnumerable<NewsListingServiceModel>> All();

        Task<int> Create(string title, string content, DateTime publishDate);

        Task<bool> Edit(int id, string title, string content, DateTime publishDate);

        Task<int> Delete(int id);

        Task<NewsListingServiceModel> FindById(int id);
    }
}
