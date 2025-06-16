namespace BuySellDotCom.Core.Persistence.Entities
{
    public class Address
    {
        public required User User { get; set; }

        public required int UserId { get; set; }

        public required string City { get; set; }

        public required string AddressValue { get; set; }

        public required int Number { get; set; }

        public string? State { get; set; }
    }
}
