using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;

namespace BuySellDotCom.Core.BaseTypes
{
    public class Email
    {
        private Email(string value)
        {
            Value = value;
        }

        public string Value { get; set; }


        public static Result<Email> Create(Maybe<string> emailOrNothing)
        {
            return emailOrNothing.ToResult("Email should not be empty")
                .Map(email => email.Trim())
                .Ensure(email => email != string.Empty, "Email should not be empty")
                .Ensure(email => email.Length <= 256, "Email is too long")
                .Ensure(email => Regex.IsMatch(email, @"^(.+)@(.+)$"), "Email is invalid")
                .Map(email => new Email(email));
        }

        public static explicit operator Email(string email)
        {
            return Create(email).Value;
        }

        public static implicit operator string(Email email)
        {
            return email.Value;
        }

    }
}