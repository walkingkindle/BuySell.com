using BuySellDotCom.Application.Interfaces.Repositories;
using BuySellDotCom.Core.Persistence.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ListingRepository(BuySellDbContext context) : IListingRepository
    {
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
            context.Listings.Add(listing);

            await context.SaveChangesAsync();
        }

        public Task DeleteAsync(Listing listing)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Listing listing)
        {
            var listingToUpdate = await context.Listings.FirstOrDefaultAsync(l => l.Id == listing.Id);

            listingToUpdate!.Category = listing.Category;

            listingToUpdate.Condition = listing.Condition;

            listingToUpdate.ImageUrl = listing.ImageUrl;

            listingToUpdate.Name = listing.Name;

            listingToUpdate.Price = listing.Price;

            await context.SaveChangesAsync();
        }

        public async Task<List<Listing>> GetByUserId(int userId) => await context.Listings.Where(u => u.UserId == userId).ToListAsync();
    }
}
