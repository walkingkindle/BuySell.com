using CSharpFunctionalExtensions;

namespace BuySellDotCom.Application.Models
{
    public class PhoneNumberModel
    {
        public string CountryCode { get; set; }

        public string Phone { get; set; }

        public string Value => $"{CountryCode}{Phone}";


        private static readonly List<string> AllowedCountryCodes = new List<string> { "+381", "+382" };


        public static Result<PhoneNumberModel> Create(Maybe<string> countryCode, Maybe<string> phone)
        {
            return phone.ToResult("Value must not be null")
                .Ensure(phoneNumber => countryCode.HasValue && AllowedCountryCodes.Contains(countryCode.Value), "Country code has no value or invalid")
                .Ensure(phoneNumber => phoneNumber.Length is >= 6 and <= 8, "Invalid phone number supplied")
                .Ensure(phoneNumber => phoneNumber.All(char.IsDigit),"All characters in string must be digits")
                .Map(phoneNumber => phoneNumber.Trim())
                .Map(phoneNumber => new PhoneNumberModel(countryCode.Value, phone.Value));

        }


        private PhoneNumberModel(string countryCode, string value)
        {
            CountryCode = countryCode;

            Phone = value;
        }

        public static explicit operator PhoneNumberModel((string countryCode, string phone) input)
        {
            return Create(input.countryCode, input.phone).Value;
        }

        public static implicit operator string(PhoneNumberModel phoneNumber)
        {
            return phoneNumber.Value;
        }
        
    }
}