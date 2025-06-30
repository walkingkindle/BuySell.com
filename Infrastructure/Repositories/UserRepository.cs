using BuySellDotCom.Application.Interfaces.Repositories;
using BuySellDotCom.Core.Persistence.Entities;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<User?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
