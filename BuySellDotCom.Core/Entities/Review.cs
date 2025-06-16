using CSharpFunctionalExtensions;

namespace BuySellDotCom.Core.Entities
{
    public partial class Review
    {
        public ReviewValue Value { get; set; }
        public int ListingId { get; set; }
        public int UserId { get; set; }

        private Review(int value, int listingId, int userId)
        {
            Value = (ReviewValue)value;

            ListingId = listingId;

            UserId = userId;
        }


        public static Result<Review> Create(Maybe<int> reviewValue, Maybe<int> ListingId, Maybe<int> userId)
        {
            return reviewValue.ToResult("Value must not be null")
                .Ensure(review => Enum.IsDefined(typeof(ReviewValue), reviewValue.Value), "Review value must be in a valid range")
                .Ensure(review => ListingId.Value > 0 && userId.Value > 0, "Listing and userIds must be valid")
                .Map(review => new Review(reviewValue.Value, ListingId.Value, userId.Value));
        }


    public static explicit operator Review((int reviewValue, int listingId, int userId) input)
    {
        return Create(input.reviewValue, input.listingId, input.userId).Value;
    }
}
}
