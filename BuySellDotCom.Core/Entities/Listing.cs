using BuySellDotCom.Core.BaseTypes;
using BuySellDotCom.Core.Enums;
using CSharpFunctionalExtensions;

namespace BuySellDotCom.Core.Entities
{
    public class Listing
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Currency Currency { get; set; } = new();
        public Condition Condition { get; set; } = new();
        public Address Address { get; set; }
        public int UserId { get; set; }
        public string ImageUrl { get; set; }
        public Category Category { get; set; }

        public static Result<Listing> Create(Maybe<string> name, Maybe<decimal> price, Maybe<Currency> currency,
            Maybe<Condition> condition, Maybe<int> userId, Maybe<string> imageUrl, Maybe<Category> category, Address address)
        {
            return name.ToResult("Name must not be null")
                .Ensure(result => price.HasValue && price.Value > 0, "Price value must be valid")
                .Ensure(result => Enum.IsDefined(typeof(Currency), currency.Value), "Currency value must be valid")
                .Ensure(result => Enum.IsDefined(typeof(Condition), condition.Value), "Condition value must be valid")
                .Ensure(result => userId.Value > 0, "User Id value must be higher than 0")
                .Ensure(result => imageUrl.HasValue, "Image url is required")
                .Ensure(result => Enum.IsDefined(typeof(Category), category.Value), "Category value must be valid")
                .Map(result => new Listing(name.Value, price.Value,
                    currency.Value, condition.Value, address,
                    userId.Value, imageUrl.Value, category.Value));
        }

        private Listing(string name, decimal price, Currency currency, Condition condition, Address address, int userId,
            string imageUrl, Category category)
        {
            Name = name;
            Price = price;
            Currency = currency;
            Condition = condition;
            Address = address;
            UserId = userId;
            ImageUrl = imageUrl;
            Category = category;
        }
    }
}
