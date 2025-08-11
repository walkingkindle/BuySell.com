using System.Net;
using AutoMapper;
using BuySellDotCom.Application.Extensions;
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
        public async Task<ApplicationResult> CreateAddress(AddressDto address)
        {
            var addressResult = AddressModel.Create(address);

            if (addressResult.IsFailure)
            {
                return ApplicationResult.Failure(Errors.BadRequest(addressResult.Error));
            }
            var user = await userRepository.GetByIdAsync(addressResult.Value.UserId);

            if (user == null)
            {
                return ApplicationResult.Failure(Errors.NotFound);
            }

            Address addressDb = mapper.Map<Address>(addressResult.Value);

            await addressRepository.AddAsync(addressDb);

            return ApplicationResult.Success();

        }
    }
}
