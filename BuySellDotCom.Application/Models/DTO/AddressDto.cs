using System.Runtime.CompilerServices;
using CSharpFunctionalExtensions;

namespace BuySellDotCom.Application.Models.DTO
{
    public record AddressDto(string City,string AddressValue, int BuildingNumber)
    {
        //public Result<AddressDto,string> Create()
        //{
        //    return this.AddressValue.ToResult("address cannot be null")
        //        .Ensure(address => !string.IsNullOrEmpty(this.AddressValue) || this.BuildingNumber <= 0, "Invalid address information")
        //        .Map(address => new AddressDto(this.City, this.AddressValue, this.BuildingNumber));
        //}

        //private AddressDto(string city, string addressValue, int buildingNumber)
        //{
        //    City = city;

        //    AddressValue = addressValue;

        //    BuildingNumber = buildingNumber;
        //}
    }
}
