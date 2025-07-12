using System.Net;
using AutoMapper;
using BuySellDotCom.Application.Extensions;
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
        public async Task<ApplicationResult> CreateReview(ReviewDto reviewOrNothing)
        {
            var reviewResult = ReviewModel.Create(reviewOrNothing);

            if (reviewResult.IsFailure)
            {
                return ApplicationResult.Failure(Errors.BadRequest(reviewResult.Error));
            }

            if (await reviewRepository.GetReviewBy(reviewResult.Value.UserId, reviewResult.Value.ListingId) !=
                null)
            {
                return ApplicationResult.Failure(Errors.Forbidden);
            }

            List<Listing> listingsForUser = await listingRepository.GetByUserId(reviewResult.Value.UserId);

            if (listingsForUser.Any())
            {
                return ApplicationResult.Failure(Errors.Forbidden);
            }

            Review review = mapper.Map<Review>(reviewResult.Value);

            await reviewRepository.AddAsync(review);

            return ApplicationResult.Success();
        }
    }
}
