namespace LearningSystem.Service.Interfaces
{
    using Models.Admin;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAdminUserService
    {
        Task<IEnumerable<AdminUsersModelsView>> AllUsersAsync();
    }
}