using BuySellDotCom.Core.Entities;
using CSharpFunctionalExtensions;

namespace BuySellDotCom.Application.Models
{
    public partial class ReviewModel
    {
        public Review.ReviewValue Value { get; set; }
        public int ListingId { get; set; }
        public int UserId { get; set; }

        private ReviewModel(int value, int listingId, int userId)
        {
            Value = (Review.ReviewValue)value;

            ListingId = listingId;

            UserId = userId;
        }


        public static Result<ReviewModel> Create(Maybe<int> reviewValue, Maybe<int> ListingId, Maybe<int> userId)
        {
            return reviewValue.ToResult("Value must not be null")
                .Ensure(review => Enum.IsDefined(typeof(Review.ReviewValue), reviewValue.Value), "Review value must be in a valid range")
                .Ensure(review => ListingId.Value > 0 && userId.Value > 0, "Listing and userIds must be valid")
                .Map(review => new ReviewModel(reviewValue.Value, ListingId.Value, userId.Value));
        }


        public static explicit operator ReviewModel((int reviewValue, int listingId, int userId) input)
        {
            return Create(input.reviewValue, input.listingId, input.userId).Value;
        }
}
}
