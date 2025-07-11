using BuySell.API.Extensions;
using BuySellDotCom.Application.Models.DTO;
using CSharpFunctionalExtensions;

namespace BuySellDotCom.Application.Interfaces.Services
{
    public interface IUserService
    {
        public Task<ApiResult> AddUser(UserDto user);

        public Task<ApiResult> UpdateUser(UserDto user, int id);

        public Task<ApiResult> DeleteUser(int id);
    }
}
