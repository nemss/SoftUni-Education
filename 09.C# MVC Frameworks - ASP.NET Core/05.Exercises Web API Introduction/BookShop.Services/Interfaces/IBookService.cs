namespace BookShop.Services.Interfaces
{
    using Models.Book;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBookService
    {
        Task<int> Create(
            string title,
            string description,
            decimal price,
            int copies,
            int? edition,
            int? ageRestriction,
            DateTime releaseDate,
            int authorId,
            string categories);

        Task<IEnumerable<BookListingServiceModel>> All(string search);

        Task<BookDetailsServiceModel> Details(int id);
    }
}