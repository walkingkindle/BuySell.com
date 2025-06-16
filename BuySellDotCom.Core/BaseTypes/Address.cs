using CSharpFunctionalExtensions;

namespace BuySellDotCom.Core.BaseTypes
{
    public class Address
    { 
        public Address(string city, string addressValue, int buildingNumber)
        {
            City = city;

            AddressValue = addressValue;

            BuildingNumber = buildingNumber;
        }

        public string City { get; set; }

        public string AddressValue { get; set; }

        public int BuildingNumber { get; set; }


        public static Result<Address> Create(Maybe<string> city, Maybe<string> addressValue, Maybe<int> buildingNumber)
        {
            return addressValue.ToResult("address cannot be null")
                .Ensure(address => string.IsNullOrEmpty(city.Value) || buildingNumber.Value <= 0, "Invalid address information")
                .Map(address => new Address(city.Value, addressValue.Value, buildingNumber.Value));

        }





    }

    //public enum City
    //{
    //TODO: For the future check against a list of cities.

    //}
}