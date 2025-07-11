using System.Net;
using AutoMapper;
using BuySell.API.Extensions;
using BuySellDotCom.Application.Interfaces.Repositories;
using BuySellDotCom.Application.Interfaces.Services;
using BuySellDotCom.Application.Models;
using BuySellDotCom.Application.Models.DTO;
using BuySellDotCom.Core.Persistence.Entities;
using CSharpFunctionalExtensions;

namespace BuySellDotCom.Application.Services
{
    public class ReviewService(IReviewRepository reviewRepository, IListingRepository listingRepository,IMapper mapper):IReviewService
    {
        public async Task<ApiResult> CreateReview(ReviewDto reviewOrNothing)
        {
            var reviewResult = ReviewModel.Create(reviewOrNothing);

            if (reviewResult.IsFailure)
            {
                return ApiResult.Failure(reviewResult.Error);
            }

            if (await reviewRepository.GetReviewBy(reviewResult.Value.UserId, reviewResult.Value.ListingId) !=
                null)
            {
                return ApiResult.Failure("This user has already reviewed this product",HttpStatusCode.Forbidden);
            }

            List<Listing> listingsForUser = await listingRepository.GetByUserId(reviewResult.Value.UserId);

            if (listingsForUser.Any())
            {
                return ApiResult.Failure("The user cannot review any listings that belong to him",HttpStatusCode.Forbidden);
            }

            Review review = mapper.Map<Review>(reviewResult.Value);

            await reviewRepository.AddAsync(review);

            return ApiResult.Success();
        }
    }
}
