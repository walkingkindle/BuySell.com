using BuySellDotCom.Application.Models.DTO;
using BuySellDotCom.Core.BaseTypes;
using BuySellDotCom.Core.Enums;
using CSharpFunctionalExtensions;

namespace BuySellDotCom.Application.Models
{
    public class ListingModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Currency Currency { get; set; } = new();
        public Condition Condition { get; set; } = new();
        public Address Address { get; set; }
        public int UserId { get; set; }
        public string ImageUrl { get; set; }
        public Category Category { get; set; }

        //public static Result<Listing> Create(Maybe<string> name, Maybe<decimal> price, Maybe<Currency> currency,
        //    Maybe<Condition> condition, Maybe<int> userId, Maybe<string> imageUrl, Maybe<Category> category, Address address)
        //{
        public static Result<ListingModel> Create(Maybe<ListingDto> listingOrNothing, Address address){
            return listingOrNothing.ToResult("Name must not be null")
                .Ensure(result => listingOrNothing.Value.Price > 0, "Price value must be valid")
                .Ensure(result => Enum.IsDefined(typeof(Currency), listingOrNothing.Value.Currency), "Currency value must be valid")
                .Ensure(result => Enum.IsDefined(typeof(Condition), listingOrNothing.Value.Condition), "Condition value must be valid")
                .Ensure(result => listingOrNothing.Value.UserId > 0, "User Id value must be higher than 0")
                .Ensure(result => !string.IsNullOrEmpty(listingOrNothing.Value.ImageUrl), "Image url is required")
                .Ensure(result => Enum.IsDefined(typeof(Category), listingOrNothing.Value.Category), "Category value must be valid")
                .Map(result => new ListingModel(listingOrNothing.Value.Name, listingOrNothing.Value.Price,
                    listingOrNothing.Value.Currency, listingOrNothing.Value.Condition, address,
                    listingOrNothing.Value.UserId, listingOrNothing.Value.ImageUrl, listingOrNothing.Value.Category));
        }

        private ListingModel(string name, decimal price, Currency currency, Condition condition, Address address, int userId,
            string imageUrl, Category category)
        {
            Name = name;
            Price = price;
            Currency = currency;
            Condition = condition;
            UserId = userId;
            ImageUrl = imageUrl;
            Category = category;
        }
    }
}
