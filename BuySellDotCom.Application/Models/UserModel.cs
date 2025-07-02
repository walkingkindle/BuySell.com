using BuySellDotCom.Core.BaseTypes;
using BuySellDotCom.Core.Enums;
using CSharpFunctionalExtensions;

namespace BuySellDotCom.Application.Models
{
    public class UserModel
    {
        public string Name { get; set; }

        public PhoneNumberModel PhoneNumber { get; set; }

        public Email EmailAddress { get; set; }

        public Address Address { get; set; }

        public int? Age { get; set; }

        public Gender Gender { get; set; }

        public static Result<UserModel> Create(Maybe<string> name, Maybe<Gender> gender, PhoneNumberModel phoneNumber,
            Email email, Address address, int age)
        {
            return name.ToResult("Name must not be null")
                .Ensure(result => name.HasValue && name.Value.Length < 150, "Invalid name value")
                .Ensure(result => Enum.IsDefined(typeof(Gender), gender), "Gender value must be valid")
                .Map(result => new UserModel(name.Value, phoneNumber, email, address, age, gender.Value));
        }


        private UserModel(string name, PhoneNumberModel phoneNumber, Email email, Address address, int age, Gender gender)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            EmailAddress = email;
            Address = address;
            Age = age;
            Gender = gender;

        }

    }


}
