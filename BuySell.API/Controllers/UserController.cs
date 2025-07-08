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
            return userResult.ToActionResult();
        }
    }
}
