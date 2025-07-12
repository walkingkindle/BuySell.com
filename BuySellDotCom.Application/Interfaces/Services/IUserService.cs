using BuySellDotCom.Application.Extensions;
using BuySellDotCom.Application.Models.DTO;
using CSharpFunctionalExtensions;

namespace BuySellDotCom.Application.Interfaces.Services
{
    public interface IUserService
    {
        public Task<ApplicationResult> AddUser(UserDto user);

        public Task<ApplicationResult> UpdateUser(UserDto user, int id);

        public Task<ApplicationResult> DeleteUser(int id);
    }
}
