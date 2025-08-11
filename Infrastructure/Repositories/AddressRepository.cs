using BuySellDotCom.Application.Interfaces.Repositories;
using BuySellDotCom.Core.Persistence.Entities;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class AddressRepository(BuySellDbContext context) : IAddressRepository{
        public Task<Address> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Address>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(Address address)
        {
            context.Addresses.Add(address);

            await context.SaveChangesAsync();
        }

        public Task DeleteAsync(Address address)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Address address)
        {
            throw new NotImplementedException();
        }
    }
}
