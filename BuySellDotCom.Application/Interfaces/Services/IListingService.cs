using BuySellDotCom.Application.Models;
using CSharpFunctionalExtensions;

namespace BuySellDotCom.Application.Interfaces.Services
{
    public interface IListingService
    {
        public Task<Result> CreateListing(Maybe<ListingModel> listing);
    }
}
