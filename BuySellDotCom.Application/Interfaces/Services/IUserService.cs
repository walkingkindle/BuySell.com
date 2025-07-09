using BuySellDotCom.Application.Models.DTO;
using CSharpFunctionalExtensions;

namespace BuySellDotCom.Application.Interfaces.Services
{
    public interface IUserService
    {
        public Task<Result> AddUser(UserDto user);

        public Task<Result> UpdateUser(UserDto user, int id);

        public Task<Result> DeleteUser(int id);
    }
}
