using BuySellDotCom.Core.Persistence.Entities;

namespace BuySellDotCom.Application.Interfaces.Repositories
{
    public interface IAddressRepository
    {
        Task<Address> GetByIdAsync(int id);
        Task<List<Address>> GetAllAsync();
        Task AddAsync(Address address);
        Task DeleteAsync(Address address);
        Task UpdateAsync(Address address);

    }
}
