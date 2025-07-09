using BuySellDotCom.Application.Models.DTO;
using BuySellDotCom.Core.Enums;
using CSharpFunctionalExtensions;

namespace BuySellDotCom.Application.Models
{
    public partial class ReviewModel
    {
        public ReviewValue Value { get; set; }
        public int ListingId { get; set; }
        public int UserId { get; set; }

        private ReviewModel(ReviewValue value, int listingId, int userId)
        {
            Value = value;

            ListingId = listingId;

            UserId = userId;
        }
        public static Result<ReviewModel> Create(Maybe<ReviewDto> reviewOrNothing)
        {
            return reviewOrNothing.ToResult("Value must not be null")
                .Ensure(review => Enum.IsDefined(typeof(ReviewValue), review.Value), "Review value must be in a valid range")
                .Ensure(review => review.ListingId > 0 && review.UserId > 0, "Listing and userIds must be valid")
                .Map(review => new ReviewModel(review.Value, review.ListingId, review.UserId));
        }
    }
}
