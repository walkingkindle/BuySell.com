using BuySellDotCom.Application.Interfaces.Repositories;
using BuySellDotCom.Core.Persistence.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ReviewRepository(BuySellDbContext context): IReviewRepository
    {
        public Task<Review?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Review>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(Review review)
        {
            await context.Reviews.AddAsync(review);

            await context.SaveChangesAsync();
        }

        public Task DeleteAsync(Review review)
        {
            throw new NotImplementedException();
        }

        public async Task<Review?> GetReviewBy(int userId, int listingId)
        {
            return await context.Reviews.AsNoTracking().FirstOrDefaultAsync(u => u.ListingId == listingId && u.UserId == userId);
        }
    }
}
