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
        public int UserId { get; set; }
        public string ImageUrl { get; set; }
        public Category Category { get; set; }

        public static Result<ListingModel> Create(Maybe<ListingDto> listingOrNothing)
        {
            return listingOrNothing.ToResult("Name must not be null")
            .Ensure(result => result.Price > 0, "Price value must be valid")
            .Ensure(result => Enum.IsDefined(typeof(Currency), result.Currency), "Currency value must be valid")
            .Ensure(result => Enum.IsDefined(typeof(Condition), result.Condition), "Condition value must be valid")
            .Ensure(result => result.UserId > 0, "User Id value must be higher than 0")
            .Ensure(result => !string.IsNullOrEmpty(result.ImageUrl), "Image url is required")
            .Ensure(result => Enum.IsDefined(typeof(Category), result.Category), "Category value must be valid")
            .Map(result => new ListingModel(result.Name, result.Price, result.Currency, result.Condition,
                result.UserId, result.ImageUrl, result.Category));
        }


        private ListingModel(string name, decimal price, Currency currency, Condition condition, int userId,
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
