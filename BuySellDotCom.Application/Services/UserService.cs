using BuySellDotCom.Application.Interfaces.Repositories;
using BuySellDotCom.Application.Interfaces.Services;
using BuySellDotCom.Application.Models;
using BuySellDotCom.Application.Models.DTO;
using BuySellDotCom.Core.BaseTypes;
using BuySellDotCom.Core.Persistence.Entities;
using CSharpFunctionalExtensions;

namespace BuySellDotCom.Application.Services
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        public async Task<Result> AddUser(Maybe<UserDto> user)
        {
            var emailResult = Email.Create(user.Value.Email);

            var phoneNumberResult = PhoneNumberModel.Create(user.Value.CountryCode, user.Value.PhoneNumber);

            var userResult = UserModel.Create(user);
  
            var combinedResult = Result.Combine(emailResult, userResult, phoneNumberResult);

            if (combinedResult.IsFailure)
            {
                return Result.Failure(combinedResult.Error);
            }

            var userDb = new User()
            {
                Name = userResult.Value.Name,
                Age = userResult.Value.Age,
                CountryCode = phoneNumberResult.Value.CountryCode,
                PhoneNumber = phoneNumberResult.Value.Phone,
                EmailAddress = emailResult.Value,
                Gender = userResult.Value.Gender,
                IsActivated = false,
            };
            await userRepository.AddAsync(userDb);

            return Result.Success();

        }
    }
}
