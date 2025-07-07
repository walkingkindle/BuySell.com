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
        public async Task<ActionResult> CreateAddress(AddressDto address)
        {
            var result = await addressService.CreateAddress(address);

            return Ok(result);

        }
    }
}
