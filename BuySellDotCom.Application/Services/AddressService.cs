using System.Net;
using AutoMapper;
using BuySell.API.Extensions;
using BuySellDotCom.Application.Interfaces.Repositories;
using BuySellDotCom.Application.Interfaces.Services;
using BuySellDotCom.Application.Models.BaseTypes;
using BuySellDotCom.Application.Models.DTO;
using BuySellDotCom.Core.Persistence.Entities;
using CSharpFunctionalExtensions;

namespace BuySellDotCom.Application.Services
{
    public class AddressService(IMapper mapper, IAddressRepository addressRepository, IUserRepository userRepository) : IAddressService
    {
        public async Task<ApiResult> CreateAddress(AddressDto address)
        {
            var addressResult = AddressModel.Create(address);

            if (addressResult.IsFailure)
            {
                return ApiResult.Failure(addressResult.Error);
            }
            var user = await userRepository.GetByIdAsync(addressResult.Value.UserId);

            if (user == null)
            {
                return ApiResult.Failure("The user with the related Id does not exist", HttpStatusCode.NotFound);
            }

            Address addressDb = mapper.Map<Address>(addressResult.Value);

            await addressRepository.AddAsync(addressDb);

            return ApiResult.Success();

        }
    }
}
