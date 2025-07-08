using BuySellDotCom.Application.Models;
using BuySellDotCom.Application.Models.DTO;
using CSharpFunctionalExtensions;

namespace BuySellDotCom.Application.Interfaces.Services
{
    public interface IListingService
    {
        public Task<Result> CreateListing(ListingDto listing);
    }
}
