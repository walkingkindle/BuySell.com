using BuySellDotCom.Core.Enums;

namespace BuySellDotCom.Application.Models.DTO
{
    public record UserDto(string Name, string CountryCode, string PhoneNumber, string Email, int AddressId, int? Age, Gender Gender);

}
