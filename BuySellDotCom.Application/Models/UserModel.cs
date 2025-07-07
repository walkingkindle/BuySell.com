using BuySellDotCom.Application.Models.DTO;
using BuySellDotCom.Core.BaseTypes;
using BuySellDotCom.Core.Enums;
using BuySellDotCom.Core.Persistence.Entities;
using CSharpFunctionalExtensions;

namespace BuySellDotCom.Application.Models
{
    public class UserModel
    {
        public string Name { get; set; }

        public int AddressId  { get; set; }

        public int? Age { get; set; }

        public Gender Gender { get; set; }

        public static Result<UserModel> Create(Maybe<UserDto> userOrNothing)
        {
            return userOrNothing.ToResult("Name must not be null")
                .Ensure(result => result.Name.Length < 150, "Invalid name value")
                .Ensure(result => Enum.IsDefined(typeof(Gender), result.Gender), "Gender value must be valid")
                .Ensure(result => result.AddressId > 0, "Invalid address Id")
                .Map(result => new UserModel(result.Name,result.Age ?? 0, result.Gender));
        }

        private UserModel(string name, int age, Gender gender)
        {
            Name = name;
            Age = age;
            Gender = gender;

        }

    }


}
