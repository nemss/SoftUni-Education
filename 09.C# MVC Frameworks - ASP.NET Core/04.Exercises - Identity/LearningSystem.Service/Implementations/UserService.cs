namespace LearningSystem.Service.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Models.Users;

    public class UserService : IUserService
    {
        private readonly LearningSystemDbContext db;

        public UserService(LearningSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<UserProfileServiceModel> ProfileAsync(string id)
            => await this.db
                .Users
                .Where(u => u.Id == id)
                .ProjectTo<UserProfileServiceModel>(new { studentId = id })
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<UserListingServiceModel>> FindAsync(string search)
            => await this.db
                .Users
                .OrderBy(c => c.UserName)
                .Where(c => c.Name.ToLower().Contains(search.ToLower()))
                .ProjectTo<UserListingServiceModel>()
                .ToListAsync();

    }
}
