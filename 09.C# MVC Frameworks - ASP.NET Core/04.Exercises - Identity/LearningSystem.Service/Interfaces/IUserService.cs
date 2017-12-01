namespace LearningSystem.Service.Interfaces
{
    using Models.Users;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserService
    {
        Task<UserProfileServiceModel> ProfileAsync(string username);

        Task<IEnumerable<UserListingServiceModel>> FindAsync(string search);
    }
}
