using BuySellDotCom.Application.Models.DTO;
using CSharpFunctionalExtensions;

namespace BuySellDotCom.Application.Interfaces.Services
{
    public interface IUserService
    {
        public Task<Result> AddUser(Maybe<UserDto> user);
    }
}
