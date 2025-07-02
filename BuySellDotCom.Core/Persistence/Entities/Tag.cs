using System.ComponentModel.DataAnnotations;

namespace BuySellDotCom.Core.Persistence.Entities
{
    public class Tag
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public required string Value { get; set; }

        [Required]
        public required Listing Listing { get; set; }

        [Required]
        public required int ListingId { get; set; }
    }
}
