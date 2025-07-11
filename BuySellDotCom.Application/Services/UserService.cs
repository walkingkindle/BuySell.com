using System.Net;
using BuySell.API.Extensions;
using BuySellDotCom.Application.Interfaces.Repositories;
using BuySellDotCom.Application.Interfaces.Services;
using BuySellDotCom.Application.Models;
using BuySellDotCom.Application.Models.DTO;
using BuySellDotCom.Core.BaseTypes;
using BuySellDotCom.Core.Persistence.Entities;
using CSharpFunctionalExtensions;

namespace BuySellDotCom.Application.Services
{
    public class UserService(IUserRepository repository) : IUserService
    {
        public async Task<ApiResult> AddUser(UserDto user)
        {
            var emailResult = Email.Create(user.Email);

            var phoneNumberResult = PhoneNumberModel.Create(user.CountryCode, user.PhoneNumber);

            var userResult = UserModel.Create(user);

            var combinedResult = Result.Combine(emailResult, userResult, phoneNumberResult);

            if (combinedResult.IsFailure)
            {
                return ApiResult.Failure(combinedResult.Error);
            }

            var userExists = await repository.GetByEmailAsync(emailResult.Value);

            if (userExists != null)
            {
                return ApiResult.Failure("User with this e-mail already exists");
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
            await repository.AddAsync(userDb);

            return ApiResult.Success();

        }

        public async Task<ApiResult> UpdateUser(UserDto userOrNothing, int userId)
        {
            User? userToChange = await repository.GetByIdAsync(userId);

            if (userToChange == null)
            {
                return ApiResult.Failure("The user with the specified Id does not exist.",HttpStatusCode.NotFound);
            }

            var emailResult = Email.Create(userOrNothing.Email);

            var phoneNumberResult = PhoneNumberModel.Create(userOrNothing.CountryCode, userOrNothing.PhoneNumber);

            var userResult = UserModel.Create(userOrNothing);

            var combinedResult = Result.Combine(emailResult, userResult, phoneNumberResult);

            if (combinedResult.IsFailure)
            {
                return ApiResult.Failure(combinedResult.Error);
            }
            //TO DO: Check if the current user is the one updating

            var userDb = new User()
            {
                Id = userId,
                Name = userResult.Value.Name,
                Age = userResult.Value.Age,
                CountryCode = phoneNumberResult.Value.CountryCode,
                PhoneNumber = phoneNumberResult.Value.Phone,
                EmailAddress = emailResult.Value,
                Gender = userResult.Value.Gender
            };

            await repository.UpdateAsync(userDb);

            return ApiResult.Success();
        }

        public async Task<ApiResult> DeleteUser(int id)
        {
            
            var user = await repository.GetByIdAsync(id);

            if (user == null)
            {
                return ApiResult.Failure("The user with the specified Id does not exist",HttpStatusCode.NotFound);
            }

            await repository.DeleteAsync(user);

            return ApiResult.Success();
        }

}
}
