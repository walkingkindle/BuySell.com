using BuySell.API.Extensions;
using BuySellDotCom.Application.Interfaces.Services;
using BuySellDotCom.Application.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BuySell.API.Controllers;

    [ApiController]
    [Route("/api/listings")]
    public class ListingsController(IListingService service) : ControllerBase    {

        [HttpPost("")]
        public async Task<IActionResult> CreateListing(ListingDto listing)
        {
            var result = await service.CreateListing(listing);

            return this.Match(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetListingById([FromRoute(Name = "id")] int listingId)
        {
            var result = await service.GetListing(listingId);

            return this.Match(result);

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateListing(ListingDto listing, [FromRoute(Name = "id")] int listingId, int userId)
        {
            var result = await service.UpdateListing(listing, listingId, userId);

            return this.Match(result);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteListing([FromRoute(Name = "id")] int listingId, int userId)
        {
            var result = await service.DeleteListing(listingId, userId);

            return this.Match(result);
        }
        
    }
