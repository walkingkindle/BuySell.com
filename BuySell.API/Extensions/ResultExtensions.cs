using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;

namespace BuySell.API.Extensions
{
    public static class ResultExtensions
    {
        public static IActionResult ToActionResult(this Result result)
        {
            if (result.IsFailure)
                return new BadRequestObjectResult(new { error = result.Error });

            return new NoContentResult();

        }
    }
}
