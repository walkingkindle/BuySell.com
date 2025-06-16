namespace BuySellDotCom.Core.Persistence.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public required string Value { get; set; }
        public required Listing Listing { get; set; }
        public required int ListingId { get; set; }
    }
}
