using BuySellDotCom.Core.Persistence.Entities;

namespace BuySellDotCom.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(int id);
        Task<List<User>> GetAllAsync();
        Task AddAsync(User user);
        Task DeleteAsync(User user);
        Task UpdateAsync(User user);

        Task<User?> GetByEmailAsync(string email);

    }
}
