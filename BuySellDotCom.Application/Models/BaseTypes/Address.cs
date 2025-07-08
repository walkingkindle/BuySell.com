using BuySellDotCom.Application.Models.DTO;
using CSharpFunctionalExtensions;

namespace BuySellDotCom.Application.Models.BaseTypes
{
    public class AddressModel
    { 
        private AddressModel(string city, string addressValue, int buildingNumber,int userId)
        {
            City = city;

            AddressValue = addressValue;

            Number = buildingNumber;

            UserId = userId;
        }

        public string City { get; set; }

        public string AddressValue { get; set; }

        public int Number { get; set; }

        public int UserId { get; set; }


        public static Result<AddressModel> Create(Maybe<AddressDto> addressOrNothing)
        {
            return addressOrNothing.ToResult("address cannot be null")
            .Ensure(address => !string.IsNullOrEmpty(address.AddressValue) || address.Number <= 0, "Invalid address information")
            .Ensure(address => address.UserId > 0,"Invalid user Id provided for address")
            .Map(address => new AddressModel(address.City, address.AddressValue, address.Number,address.UserId));


        }





    }

    //public enum City
    //{
    //TODO: For the future check against a list of cities.

    //}
}