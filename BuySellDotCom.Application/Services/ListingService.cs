using System.Net;
using AutoMapper;
using BuySellDotCom.Application.Extensions;
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
        public async Task<ApplicationResult> CreateListing(ListingDto listing)
        {
            Result<ListingModel> listingResult = ListingModel.Create(listing);

            if (listingResult.IsFailure)
            {
                return ApplicationResult.Failure(Errors.BadRequest(listingResult.Error));
            }

            var user = await userRepository.GetByIdAsync(listingResult.Value.UserId);

            if (user == null)
            {
                return ApplicationResult.Failure(Errors.NotFound);
            }

            Listing listingDb = mapper.Map<ListingModel, Listing>(listingResult.Value);

            await listingRepository.AddAsync(listingDb);

            return ApplicationResult.Success();
        }

        public async Task<ApplicationResult> UpdateListing(ListingDto listingOrNothing, int listingId, int userId)
        {
            Listing? listing = await listingRepository.GetByIdAsync(listingId);

            if (listing == null)
            {
                return ApplicationResult.Failure(Errors.NotFound);
            }

            if (listing.UserId != userId)
            {
                return ApplicationResult.Failure(Errors.Forbidden);
            }

            Result<ListingModel> listingResult = ListingModel.Create(listingOrNothing);

            if (listingResult.IsFailure)
            {
                return ApplicationResult.Failure(Errors.BadRequest(listingResult.Error));
            }

            Listing listingDb = mapper.Map<ListingModel, Listing>(listingResult.Value);

            listingDb.Id = listingId;

            await listingRepository.UpdateAsync(listingDb);

            return ApplicationResult.Success();
        }

        public async Task<ApplicationResult> DeleteListing(int listingId, int userId)
        {
            Listing? listing = await listingRepository.GetByIdAsync(listingId);

            if (listing == null)
            {
                return ApplicationResult.Failure(Errors.NotFound);
            }

            if (listing.UserId != userId)
            {
                return ApplicationResult.Failure(Errors.Forbidden);
            }

            await listingRepository.DeleteAsync(listing);

            return ApplicationResult.Success();
        }

        public async Task<ApplicationResult<Listing>> GetListing(int id)
        {
            Listing? listing = await listingRepository.GetByIdAsync(id);

            if (listing == null)
            {
                return ApplicationResult<Listing>.Failure(Errors.NotFound);
            }

            return ApplicationResult<Listing>.Success(listing);
        }
    }
}

