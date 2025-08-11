using System.ComponentModel.DataAnnotations;

namespace BuySellDotCom.Core.Persistence.Entities
{
    public class Review
    {
        public int Id { get; set; }

        [Required]
        public required Listing Listing { get; set; }

        [Range(1,5)]
        [Required]
        public required int Value { get; set; }

        [Required]
        public required int ListingId { get; set; }

        [Required]
        public required int UserId { get; set; }
    }
}
