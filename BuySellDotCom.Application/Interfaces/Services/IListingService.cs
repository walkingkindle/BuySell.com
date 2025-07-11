using BuySell.API.Extensions;
using BuySellDotCom.Application.Models.DTO;
using BuySellDotCom.Core.Persistence.Entities;
using CSharpFunctionalExtensions;

namespace BuySellDotCom.Application.Interfaces.Services
{
    public interface IListingService
    {
        public Task<ApiResult> CreateListing(ListingDto listing);

        public Task<ApiResult> UpdateListing(ListingDto listing, int listingId, int userId);

        public Task<ApiResult> DeleteListing(int listingId, int userId);

        public Task<ApiResult<Listing>> GetListing(int listingId);
    }
}
