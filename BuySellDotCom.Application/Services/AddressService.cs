using AutoMapper;
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
        public async Task<Result> CreateAddress(AddressDto address)
        {
            var addressResult = AddressModel.Create(address);

            if (addressResult.IsFailure)
            {
                return Result.Failure(addressResult.Error);
            }
            var user = await userRepository.GetByIdAsync(addressResult.Value.UserId);

            if (user == null)
            {
                return Result.Failure("The user with the related Id does not exist");
            }

            Address addressDb = mapper.Map<Address>(addressResult.Value);

            await addressRepository.AddAsync(addressDb);

            return Result.Success();

        }
    }
}
