using BuySellDotCom.Application.Extensions;
using BuySellDotCom.Application.Models.DTO;

namespace BuySellDotCom.Application.Interfaces.Services
{
    public interface IAddressService
    {
        public Task<ApplicationResult> CreateAddress(AddressDto address);
    }
}
