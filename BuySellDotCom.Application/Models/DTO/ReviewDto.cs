using BuySellDotCom.Core.Enums;

namespace BuySellDotCom.Application.Models.DTO;
public record ReviewDto(ReviewValue Value, int ListingId, int UserId);

