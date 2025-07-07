using BuySellDotCom.Application.Interfaces.Repositories;
using BuySellDotCom.Core.Persistence.Entities;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class UserRepository(BuySellDbContext context) : IUserRepository
    {
        public Task<User?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(User user)
        {
            context.Users.Add(user);

            await context.SaveChangesAsync();
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
