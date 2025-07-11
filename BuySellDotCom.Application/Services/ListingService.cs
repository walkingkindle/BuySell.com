using System.Net;
using AutoMapper;
using BuySell.API.Extensions;
using BuySellDotCom.Application.Interfaces.Repositories;
using BuySellDotCom.Application.Interfaces.Services;
using BuySellDotCom.Application.Models;
using BuySellDotCom.Application.Models.DTO;
using BuySellDotCom.Core.Persistence.Entities;
using CSharpFunctionalExtensions;

namespace BuySellDotCom.Application.Services
{
    public class ListingService(IMapper mapper, IListingRepository listingRepository, IUserRepository userRepository)
        : IListingService
    {
        public async Task<ApiResult> CreateListing(ListingDto listing)
        {
            Result<ListingModel> listingResult = ListingModel.Create(listing);

            if (listingResult.IsFailure)
            {
                return ApiResult.Failure(listingResult.Error);

            }

            var user = await userRepository.GetByIdAsync(listingResult.Value.UserId);

            if (user == null)
            {
                return ApiResult.Failure("The user with the id with this listing does not exist",
                    HttpStatusCode.NotFound);
            }

            Listing listingDb = mapper.Map<ListingModel, Listing>(listingResult.Value);

            await listingRepository.AddAsync(listingDb);

            return ApiResult.Success();
        }

        public async Task<ApiResult> UpdateListing(ListingDto listingOrNothing, int listingId, int userId)
        {
            Listing? listing = await listingRepository.GetByIdAsync(listingId);

            if (listing == null)
            {
                return ApiResult.Failure("The specified listing does not exist", HttpStatusCode.NotFound);
            }

            if (listing.UserId != userId)
            {
                return ApiResult.Failure("The specified listing does not belong to the specified user",
                    HttpStatusCode.Forbidden);
            }

            Result<ListingModel> listingResult = ListingModel.Create(listingOrNothing);

            if (listingResult.IsFailure)
            {
                return ApiResult.Failure("Invalid listing provided");
            }

            Listing listingDb = mapper.Map<ListingModel, Listing>(listingResult.Value);

            listingDb.Id = listingId;

            await listingRepository.UpdateAsync(listingDb);

            return ApiResult.Success();
        }

        public async Task<ApiResult> DeleteListing(int listingId, int userId)
        {
            Listing? listing = await listingRepository.GetByIdAsync(listingId);

            if (listing == null)
            {
                return ApiResult.Failure("The specified listing does not exist", HttpStatusCode.NotFound);
            }

            if (listing.UserId != userId)
            {
                return ApiResult.Failure("The specified listing does not belong to the specified user", HttpStatusCode.Forbidden);
            }

            await listingRepository.DeleteAsync(listing);

            return ApiResult.Success();
        }

        public async Task<ApiResult<Listing>> GetListing(int id)
        {
            Listing? listing = await listingRepository.GetByIdAsync(id);

            if (listing == null)
            {
                return ApiResult<Listing>.Failure("The specified listing does not exist", HttpStatusCode.NotFound);
            }

            return ApiResult<Listing>.Success(listing);
        }
    }
}

