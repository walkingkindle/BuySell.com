using System.Text.RegularExpressions;
using BuySell.API.Extensions;
using BuySellDotCom.Application.Interfaces.Services;
using BuySellDotCom.Application.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BuySell.API.Controllers
{
    [ApiController]
    [Route("api/addresses")]
    public class AddressController(IAddressService addressService) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> CreateAddress(AddressDto address)
        {
            var result = await addressService.CreateAddress(address);

            return this.Match(result);

        }
    }
}
