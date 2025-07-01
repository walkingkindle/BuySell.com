using BuySellDotCom.Application.Interfaces.Repositories;
using BuySellDotCom.Core.Persistence.Entities;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class ListingRepository : IListingRepository
    {
        private readonly BuySellDbContext _context;

        public ListingRepository(BuySellDbContext context)
        {
            _context = context;

        }
        public Task<Listing?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Listing>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(Listing listing)
        {
            _context.Listings.Add(listing);

            await _context.SaveChangesAsync();
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
