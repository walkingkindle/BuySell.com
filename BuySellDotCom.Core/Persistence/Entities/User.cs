using System.ComponentModel.DataAnnotations;
using BuySellDotCom.Core.Enums;

namespace BuySellDotCom.Core.Persistence.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(2)]
        public required string Name { get; set; }

        [Required]
        [MaxLength(5)]
        public required string CountryCode { get; set; }

        [Required]
        [MaxLength(10)]
        [MinLength(6)]
        public required string PhoneNumber { get; set; }

        [Required]
        [MaxLength(255)]
        [EmailAddress]
        public required string EmailAddress { get; set; }
        public bool IsActivated { get; set; }

        public bool IsDeleted { get; set; }

        [Range(0,150)]
        public int? Age { get; set; }
        public Gender? Gender { get; set; }
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public ICollection<Listing> Listings { get; set; } = new List<Listing>();

    }

}
