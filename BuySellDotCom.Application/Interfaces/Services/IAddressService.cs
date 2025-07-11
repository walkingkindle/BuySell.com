using BuySell.API.Extensions;
using BuySellDotCom.Application.Models.DTO;
using CSharpFunctionalExtensions;

namespace BuySellDotCom.Application.Interfaces.Services
{
    public interface IAddressService
    {
        public Task<ApiResult> CreateAddress(AddressDto address);
    }
}
