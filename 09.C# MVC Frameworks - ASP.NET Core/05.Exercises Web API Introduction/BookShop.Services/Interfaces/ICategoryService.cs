namespace BookShop.Services.Interfaces
{
    using Models.Category;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoryService
    {
        Task<IEnumerable<CategoryServiceModel>> All();

        Task<int> Create(string name);

        Task<bool> Exists(string name);

        Task<CategoryServiceModel> FindById(int id);

        Task<int> Delete(int id);

        Task<bool> Edit(int id, string name);
    }
}