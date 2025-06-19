using BuySellDotCom.Core.Enums;

namespace BuySellDotCom.Core.Persistence.Entities
{
    public class User
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string CountryCode { get; set; }
        public required string PhoneNumber { get; set; }
        public required string EmailAddress { get; set; }
        public bool IsActivated { get; set; }
        public int? Age { get; set; }
        public Gender? Gender { get; set; }
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public ICollection<Listing> Listings { get; set; } = new List<Listing>();
    }
}
