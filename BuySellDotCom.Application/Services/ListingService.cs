using AutoMapper;
using BuySellDotCom.Application.Interfaces.Repositories;
using BuySellDotCom.Application.Interfaces.Services;
using BuySellDotCom.Application.Models;
using BuySellDotCom.Application.Models.DTO;
using BuySellDotCom.Core.Persistence.Entities;
using CSharpFunctionalExtensions;

namespace BuySellDotCom.Application.Services
{
    public class ListingService(IMapper mapper, IListingRepository listingRepository, IUserRepository userRepository) : IListingService
    {
        public async Task<Result> CreateListing(ListingDto listing)
        {
            Result<ListingModel> listingResult = ListingModel.Create(listing);

            if (listingResult.IsFailure)
            {
                return Result.Failure<ListingModel>(listingResult.Error);
            }

            var user = await userRepository.GetByIdAsync(listingResult.Value.UserId);

            if (user == null)
            {
                return Result.Failure("The user with the id with this listing does not exist");
            }

            Listing listingDb = mapper.Map<ListingModel,Listing>(listingResult.Value);

            await listingRepository.AddAsync(listingDb);

            return Result.Success();
        }

        public async Task<Result> UpdateListing(ListingDto listingOrNothing, int listingId, int userId)
        {
            Listing? listing = await listingRepository.GetByIdAsync(listingId);

            if (listing == null)
            {
                return Result.Failure("The specified listing does not exist");
            }

            if (listing.UserId != userId)
            {
                return Result.Failure("The specified listing does not belong to the specified user");
            }

            Result<ListingModel> listingResult = ListingModel.Create(listingOrNothing);

            if (listingResult.IsFailure)
            {
                return Result.Failure("Invalid listing provided");
            }

            Listing listingDb = mapper.Map<ListingModel, Listing>(listingResult.Value);

            listingDb.Id = listingId;

            await listingRepository.UpdateAsync(listingDb);

            return Result.Success();
        }
    }
}
