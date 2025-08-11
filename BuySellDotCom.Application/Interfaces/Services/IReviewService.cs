using BuySellDotCom.Application.Extensions;
using BuySellDotCom.Application.Models.DTO;
using CSharpFunctionalExtensions;

namespace BuySellDotCom.Application.Interfaces.Services
{
    public interface IReviewService
    {
        public Task<ApplicationResult> CreateReview(ReviewDto review);
    }
}
