using AutoMapper;
using BuySellDotCom.Application.Interfaces.Repositories;
using BuySellDotCom.Application.Interfaces.Services;
using BuySellDotCom.Application.Models;
using BuySellDotCom.Core.Persistence.Entities;
using CSharpFunctionalExtensions;
using Address = BuySellDotCom.Core.BaseTypes.Address;

namespace BuySellDotCom.Application.Services
{
    public class ListingService : IListingService
    {
        private readonly IMapper _mapper;

        private readonly IListingRepository _listingRepository;
        public ListingService(IMapper mapper, IListingRepository listingRepository)
        {
            _mapper = mapper;
            _listingRepository = listingRepository;

        }
        public async Task<Result> CreateListing(Maybe<ListingModel> listing)
        {
            Result<Address> addressResult = Address.Create(listing.Value.Address);

            if (addressResult.IsFailure)
            {
                return Result.Failure<ListingModel>(addressResult.Error);
            }

            Result<ListingModel> listingResult = ListingModel.Create(listing);

            if (listingResult.IsFailure)
            {
                return Result.Failure<ListingModel>(listingResult.Error);
            }

            Listing listingDb = _mapper.Map<ListingModel,Listing>(listingResult.Value);

            await _listingRepository.AddAsync(listingDb);

            return Result.Success();



        }
    }
}
