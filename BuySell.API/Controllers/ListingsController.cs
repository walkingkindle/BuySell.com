using BuySellDotCom.Application.Interfaces.Services;
using BuySellDotCom.Application.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BuySell.API.Controllers;

    [ApiController]
    [Route("/api/listings")]
    public class ListingsController(IListingService listingService) : ControllerBase    {

        [HttpPost("")]
        public async Task<ActionResult> CreateListing(ListingDto listing)
        {
            var result = await listingService.CreateListing(listing);

            return Ok(result);
        }
        
    }
