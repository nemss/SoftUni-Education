namespace LearningSystem.Service.Interfaces
{
    using System.Threading.Tasks;
    using Models.Users;

    public interface IUserService
    {
        Task<UserProfileServiceModel> ProfileAsync(string username);
    }
}
