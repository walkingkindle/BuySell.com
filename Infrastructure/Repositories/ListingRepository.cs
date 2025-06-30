using BuySellDotCom.Application.Interfaces.Repositories;
using BuySellDotCom.Core.Persistence.Entities;

namespace Infrastructure.Repositories
{
    public class ListingRepository : IListingRepository
    {
        public Task<Listing?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Listing>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Listing listing)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Listing listing)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Listing listing)
        {
            throw new NotImplementedException();
        }
    }
}
