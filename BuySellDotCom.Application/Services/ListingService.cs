using AutoMapper;
using BuySellDotCom.Application.Interfaces.Repositories;
using BuySellDotCom.Application.Interfaces.Services;
using BuySellDotCom.Application.Models;
using BuySellDotCom.Application.Models.DTO;
using BuySellDotCom.Core.BaseTypes;
using BuySellDotCom.Core.Persistence.Entities;
using CSharpFunctionalExtensions;

namespace BuySellDotCom.Application.Services
{
    public class ListingService(IMapper mapper, IListingRepository listingRepository) : IListingService
    {
        public async Task<Result> CreateListing(Maybe<ListingDto> listing)
        {
            Result<ListingModel> listingResult = ListingModel.Create(listing);

            if (listingResult.IsFailure)
            {
                return Result.Failure<ListingModel>(listingResult.Error);
            }

            Listing listingDb = mapper.Map<ListingModel,Listing>(listingResult.Value);

            await listingRepository.AddAsync(listingDb);

            return Result.Success();
        }
    }
}
