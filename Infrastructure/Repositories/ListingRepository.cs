using BuySellDotCom.Application.Interfaces.Repositories;
using BuySellDotCom.Core.Persistence.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ListingRepository(BuySellDbContext context) : IListingRepository
    {
        public async Task<Listing?> GetByIdAsync(int id)
        {
            return await context.Listings.FirstOrDefaultAsync(u => u.Id == id);
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
            var listingToUpdate = await context.Listings.FindAsync(listing.Id);

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
