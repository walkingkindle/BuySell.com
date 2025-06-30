using BuySellDotCom.Application.Interfaces.Services;
using BuySellDotCom.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuySell.API.Controllers;

    [ApiController]
    [Route("/api/listings")]
    public class ListingsController(IListingService listingService) : ControllerBase    {

        [HttpPost("")]
        public async Task<ActionResult> CreateListing(ListingModel listing)
        {
            var result = listingService.CreateListing(listing);

            return Ok(result);
        }
        
    }
