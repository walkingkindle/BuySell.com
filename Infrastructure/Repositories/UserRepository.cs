using BuySellDotCom.Application.Interfaces.Repositories;
using BuySellDotCom.Core.Persistence.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository(BuySellDbContext context) : IUserRepository
    {
        public async Task<User?> GetByIdAsync(int id)
        {
            return await context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
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

        public async Task DeleteAsync(User user)
        {
            user.IsDeleted = true;
            user.IsActivated = false;
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            var userToUpdate = await context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);

            userToUpdate!.Name = user.Name;

            userToUpdate.Age = user.Age;

            userToUpdate.CountryCode = user.CountryCode;

            userToUpdate.EmailAddress = user.EmailAddress;

            userToUpdate.Gender = user.Gender;

            userToUpdate.PhoneNumber = userToUpdate.PhoneNumber;

            await context.SaveChangesAsync();
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.EmailAddress == email);

        }
    }
}
