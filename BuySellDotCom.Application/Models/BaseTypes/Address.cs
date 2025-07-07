using BuySellDotCom.Application.Models.DTO;
using CSharpFunctionalExtensions;

namespace BuySellDotCom.Core.BaseTypes
{
    public class AddressModel
    { 
        private AddressModel(string city, string addressValue, int buildingNumber)
        {
            City = city;

            AddressValue = addressValue;

            BuildingNumber = buildingNumber;
        }

        public string City { get; set; }

        public string AddressValue { get; set; }

        public int BuildingNumber { get; set; }


        public static Result<AddressModel> Create(Maybe<AddressDto> addressOrNothing)
        {
            return addressOrNothing.ToResult("address cannot be null")
            .Ensure(address => !string.IsNullOrEmpty(addressOrNothing.Value.AddressValue) || addressOrNothing.Value.BuildingNumber <= 0, "Invalid address information")
            .Map(address => new AddressModel(addressOrNothing.Value.City, addressOrNothing.Value.AddressValue, addressOrNothing.Value.BuildingNumber));


        }





    }

    //public enum City
    //{
    //TODO: For the future check against a list of cities.

    //}
}