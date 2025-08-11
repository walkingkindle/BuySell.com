using BuySellDotCom.Application.Extensions;
using BuySellDotCom.Application.Models.DTO;
using BuySellDotCom.Core.Persistence.Entities;
using CSharpFunctionalExtensions;

namespace BuySellDotCom.Application.Interfaces.Services
{
    public interface IListingService
    {
        public Task<ApplicationResult> CreateListing(ListingDto listing);

        public Task<ApplicationResult> UpdateListing(ListingDto listing, int listingId, int userId);

        public Task<ApplicationResult> DeleteListing(int listingId, int userId);

        public Task<ApplicationResult<Listing>> GetListing(int listingId);
    }
}
