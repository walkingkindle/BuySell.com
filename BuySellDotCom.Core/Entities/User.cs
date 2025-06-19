using BuySellDotCom.Core.BaseTypes;
using BuySellDotCom.Core.Enums;
using CSharpFunctionalExtensions;

namespace BuySellDotCom.Core.Entities
{
    public class User
    {
        public string Name { get; set; }

        public PhoneNumber PhoneNumber { get; set; }

        public Email EmailAddress { get; set; }

        public Address Address { get; set; }

        public int? Age { get; set; }

        public Gender Gender { get; set; }

        public static Result<User> Create(Maybe<string> name, Maybe<Gender> gender, PhoneNumber phoneNumber,
            Email email, Address address, int age)
        {
            return name.ToResult("Name must not be null")
                .Ensure(result => Enum.IsDefined(typeof(Gender), gender), "Gender value must be valid")
                .Map(result => new User(name.Value, phoneNumber, email, address, age, gender.Value));
        }


        private User(string name, PhoneNumber phoneNumber, Email email, Address address, int age, Gender gender)
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
