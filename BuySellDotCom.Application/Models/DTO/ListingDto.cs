using BuySellDotCom.Core.BaseTypes;
using BuySellDotCom.Core.Enums;

namespace BuySellDotCom.Application.Models.DTO
{
    public record ListingDto
    {
        public required string Name { get; init; }
        public required decimal Price { get; init; }
        public required Currency Currency { get; init; }
        public required Condition Condition { get; init; }
        public required string City { get; init; }
        public required string Address { get; init; }
        public required string ImageUrl { get; set; }
        public required int BuildingNumber { get; init; }
        public required int UserId { get; init; }
        public required Category Category { get; init; }

    }
}
