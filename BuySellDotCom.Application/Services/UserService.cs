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
        public async Task<Result> AddUser(UserDto user)
        {
            var emailResult = Email.Create(user.Email);

            var phoneNumberResult = PhoneNumberModel.Create(user.CountryCode, user.PhoneNumber);

            var userResult = UserModel.Create(user);

            var combinedResult = Result.Combine(emailResult, userResult, phoneNumberResult);

            if (combinedResult.IsFailure)
            {
                return Result.Failure(combinedResult.Error);
            }

            var userExists = await repository.GetByEmailAsync(emailResult.Value);

            if (userExists != null)
            {
                return Result.Failure("User with this e-mail already exists");
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

            return Result.Success();

        }

        public async Task<Result> UpdateUser(UserDto userOrNothing, int userId)
        {
            User? userToChange = await repository.GetByIdAsync(userId);

            if (userToChange == null)
            {
                return Result.Failure("The user with the specified Id does not exist.");
            }

            var emailResult = Email.Create(userOrNothing.Email);

            var phoneNumberResult = PhoneNumberModel.Create(userOrNothing.CountryCode, userOrNothing.PhoneNumber);

            var userResult = UserModel.Create(userOrNothing);

            var combinedResult = Result.Combine(emailResult, userResult, phoneNumberResult);

            if (combinedResult.IsFailure)
            {
                return Result.Failure(combinedResult.Error);
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

            return Result.Success();
        }

        public async Task<Result> DeleteUser(int id)
        {
            
            var user = await repository.GetByIdAsync(id);

            if (user == null)
            {
                return Result.Failure("The user with the specified Id does not exist");
            }

            await repository.DeleteAsync(user);

            return Result.Success();
        }

}
}
