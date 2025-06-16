using System.ComponentModel.DataAnnotations;

namespace BuySellDotCom.Core.Persistence.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public required Listing Listing { get; set; }
        [Range(1,5)]
        public required int Value { get; set; }
        public required int ListingId { get; set; }
    }
}
