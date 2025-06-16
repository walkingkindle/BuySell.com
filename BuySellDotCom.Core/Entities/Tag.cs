using CSharpFunctionalExtensions;

namespace BuySellDotCom.Core.Entities
{
    public class Tag
    {
        private Tag(int listingId, string value)
        {
            ListingId = listingId;

            Value = value;

        }
        public int ListingId { get; set; }

        public string Value { get; set; }

        public static Result<Tag> Create(Maybe<int> listingId, Maybe<string> tag)
        {
            return tag.ToResult("Value must not be null")
                .Ensure(tag => listingId.Value > 0, "Invalid listing Id")
                .Map(tagResult => new Tag(listingId.Value, tag.Value));
        }
    }
}
