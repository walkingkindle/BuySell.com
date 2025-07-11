using BuySell.API.Extensions;
using BuySellDotCom.Application.Models.DTO;
using CSharpFunctionalExtensions;

namespace BuySellDotCom.Application.Interfaces.Services
{
    public interface IReviewService
    {
        public Task<ApiResult> CreateReview(ReviewDto review);
    }
}
