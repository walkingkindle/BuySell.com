using BuySellDotCom.Core.Persistence.Entities;

namespace BuySellDotCom.Application.Interfaces.Repositories
{
    public interface IAddressRepository
    {
        Task<Address> GetByIdAsync(int id);
        Task<ICollection<Address>> GetAllAsync();
        Task AddAsync(Address address);
        Task DeleteAsync(Address address);
        Task UpdateAsync(Address address);

    }
}
