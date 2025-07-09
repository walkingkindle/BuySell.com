using BuySell.API.Extensions;
using BuySellDotCom.Application.Interfaces.Services;
using BuySellDotCom.Application.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BuySell.API.Controllers;

    [ApiController]
    [Route("/api/listings")]
    public class ListingsController(IListingService listingService) : ControllerBase    {

        [HttpPost("")]
        public async Task<IActionResult> CreateListing(ListingDto listing)
        {
            var result = await listingService.CreateListing(listing);

            return result.ToActionResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateListing(ListingDto listing, [FromRoute(Name = "id")] int listingId, int userId)
        {
            var result = await listingService.UpdateListing(listing, listingId, userId);

            return result.ToActionResult();

        }
        
    }
