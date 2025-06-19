using System.ComponentModel.DataAnnotations;

namespace BuySellDotCom.Core.Persistence.Entities
{
    public class Address
    {
        public int Id { get; set; }
        [Required]
        public required User User { get; set; }

        [Required]
        public required int UserId { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(150)]
        public required string City { get; set; }

        [MinLength(1)]
        [MaxLength(300)]
        public required string AddressValue { get; set; }

        [MinLength(6)]
        [MaxLength(8)]
        public required int Number { get; set; }

        [MinLength(5)]
        [MaxLength(100)]
        public string? State { get; set; }
    }
}
