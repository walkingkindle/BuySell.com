using BuySellDotCom.Core.Persistence.Entities;

namespace BuySellDotCom.Application.Interfaces.Repositories;
    public interface IListingRepository
    {
        Task<Listing?> GetByIdAsync(int id);
        Task<List<Listing>> GetAllAsync();
        Task AddAsync(Listing listing);
        Task DeleteAsync(Listing listing);
        Task UpdateAsync(Listing listing);
    }
