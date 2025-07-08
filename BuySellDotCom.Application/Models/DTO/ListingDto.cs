using BuySellDotCom.Core.Enums;
namespace BuySellDotCom.Application.Models.DTO;

public record ListingDto(
    string Name,
    decimal Price,
    Currency Currency,
    Condition Condition,
    string ImageUrl,
    int UserId,
    Category Category);
