using BuySellDotCom.Core.Persistence.Entities;

namespace BuySellDotCom.Application.Interfaces.Repositories
{
    public interface IReviewRepository
    {
        Task<Review?> GetByIdAsync(int id);
        Task<List<Review>> GetAllAsync();
        Task AddAsync(Review review);
        Task DeleteAsync(Review review);
        Task<Review?> GetReviewBy(int userId, int listingId);
    }
}
