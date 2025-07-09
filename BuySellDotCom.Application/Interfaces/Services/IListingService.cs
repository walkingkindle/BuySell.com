using BuySellDotCom.Application.Models.DTO;
using CSharpFunctionalExtensions;

namespace BuySellDotCom.Application.Interfaces.Services
{
    public interface IListingService
    {
        public Task<Result> CreateListing(ListingDto listing);

        public Task<Result> UpdateListing(ListingDto listing, int listingId, int userId);
    }
}
