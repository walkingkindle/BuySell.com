using BuySellDotCom.Core.Enums;

namespace BuySellDotCom.Core.Persistence.Entities
{
    public class Listing
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required decimal Price { get; set; }
        public required Condition Condition { get; set; }
        public required Address ShippingAddress { get; set; }
        public string? ImageUrl { get; set; }
        public Category Category { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Tag> Tags { get; set; }
        public required User User { get; set; }
        public required int UserId { get; set; }
    }
}
