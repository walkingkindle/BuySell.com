using CSharpFunctionalExtensions;

namespace BuySellDotCom.Core.BaseTypes
{
    public class Address
    { 
        private Address(string city, string addressValue, int buildingNumber)
        {
            City = city;

            AddressValue = addressValue;

            BuildingNumber = buildingNumber;
        }

        public string City { get; set; }

        public string AddressValue { get; set; }

        public int BuildingNumber { get; set; }


        //public static Result<Address> Create(Maybe<string> city, Maybe<string> addressValue, Maybe<int> buildingNumber)
        //{
        public static Result<Address> Create(Maybe<Address> addressOrNothing){
            return addressOrNothing.ToResult("address cannot be null")
                .Ensure(address => string.IsNullOrEmpty(addressOrNothing.Value.City) || addressOrNothing.Value.BuildingNumber <= 0, "Invalid address information")
                .Map(address => new Address(addressOrNothing.Value.City, addressOrNothing.Value.AddressValue, addressOrNothing.Value.BuildingNumber));

        }





    }

    //public enum City
    //{
    //TODO: For the future check against a list of cities.

    //}
}