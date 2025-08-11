using System.Text.RegularExpressions;
using BuySell.API.Extensions;
using BuySellDotCom.Application.Interfaces.Services;
using BuySellDotCom.Application.Models.DTO;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;

namespace BuySell.API.Controllers
{

    [ApiController]
    [Route("/api/users")]
    public class UserController(IUserService service) : ControllerBase
    {

        [HttpPost("")]
        public async Task<IActionResult> CreateUser(UserDto user)
        { 
            var userResult = await service.AddUser(user);
            return this.Match(userResult);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(UserDto user, [FromRoute(Name = "id")] int userId)
        {
            var result = await service.UpdateUser(user, userId);

            return this.Match(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute(Name = "id")] int userId)
        {
            //TO DO: AUTHORIZE THIS SO THAT ONLY THE USER HIMSELF CAN DELETE HIS ACCOUNT OR THE ADMIN
            var result = await service.DeleteUser(userId);

            return this.Match(result);
        }

    }
}
