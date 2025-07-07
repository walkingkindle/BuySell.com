using AutoMapper;
using BuySellDotCom.Application.Interfaces.Repositories;
using BuySellDotCom.Application.Interfaces.Services;
using BuySellDotCom.Application.Models.DTO;
using BuySellDotCom.Core.BaseTypes;
using BuySellDotCom.Core.Persistence.Entities;
using CSharpFunctionalExtensions;

namespace BuySellDotCom.Application.Services
{
    public class AddressService(IMapper mapper, IAddressRepository addressRepository) : IAddressService
    {
        public async Task<Result> CreateAddress(AddressDto address)
        {
            var addressResult = AddressModel.Create(address);

            if (addressResult.IsFailure)
            {
                return Result.Failure(addressResult.Error);
            }

            Address addressDb = mapper.Map<Address>(addressResult.Value);


            await addressRepository.AddAsync(addressDb);

            return Result.Success();

        }
    }
}
