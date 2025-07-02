using CSharpFunctionalExtensions;

namespace BuySellDotCom.Application.Models
{
    public class TagModel
    {
        private TagModel(int listingId, string value)
        {
            ListingId = listingId;

            Value = value;

        }
        public int ListingId { get; set; }

        public string Value { get; set; }

        public static Result<TagModel> Create(Maybe<int> listingId, Maybe<string> tag)
        {
            return tag.ToResult("Value must not be null")
                .Ensure(result => tag.Value.Length is > 1 and < 150,"Tag value must be valid")
                .Ensure(tag => listingId.Value > 0, "Invalid listing Id")
                .Map(tagResult => new TagModel(listingId.Value, tag.Value));
        }
    }
}
