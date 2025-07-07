using BuySellDotCom.Core.Enums;
using CSharpFunctionalExtensions;

namespace BuySellDotCom.Application.Models.DTO
{
    public record ListingDto(string Name, decimal Price, Currency Currency, Condition Condition, string ImageUrl, int AddressId, int UserId, Category Category)
    {
        //public ListingDto(string name, decimal price, Currency currency, Condition condition, Address address, int userId, string imageUrl, Category category)
        //{
        //    Name = name;
        //    Price = price;
        //    Currency = currency;
        //    Condition = condition;
        //    City = address.City;
        //    BuildingNumber = address.BuildingNumber;
        //    Address = address.AddressValue;
        //    UserId = userId;
        //    ImageUrl = imageUrl;
        //    Category = category;
        //}



        //public Result<ListingDto,string> Create(Address address)
        //{
        //    return this.Name.ToResult("Name must not be null")
        //        .Ensure(result => this.Price > 0, "Price value must be valid")
        //        .Ensure(result => Enum.IsDefined(typeof(Currency), this.Currency), "Currency value must be valid")
        //        .Ensure(result => Enum.IsDefined(typeof(Condition), this.Condition), "Condition value must be valid")
        //        .Ensure(result => this.UserId > 0, "User Id value must be higher than 0")
        //        .Ensure(result => !string.IsNullOrEmpty(this.ImageUrl), "Image url is required")
        //        .Ensure(result => Enum.IsDefined(typeof(Category), this.Category), "Category value must be valid")
        //        .Map(result => new ListingDto(this.Name, this.Price, this.Currency, this.Condition, address,
        //            this.UserId, this.ImageUrl, this.Category));


        //}


    }
}
