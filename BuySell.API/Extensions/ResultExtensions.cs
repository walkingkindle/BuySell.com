using System.Net;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;

namespace BuySell.API.Extensions
{
    public static class ResultExtensions
    {
        public static IActionResult ToActionResult(this ApiResult apiResult)
        {
            if (apiResult.Result.IsFailure)
            {
                return new ObjectResult(new { error = apiResult.Result.Error })
                {
                    StatusCode = (int)apiResult.StatusCode
                };
            }

            return new StatusCodeResult((int)apiResult.StatusCode);

        }

        public static IActionResult ToActionResult<T>(this ApiResult<T> apiResult) where T: class
        {
            if (apiResult.Result.IsFailure)
            {
                return new ObjectResult(new { error = apiResult.Result.Error })
                {
                    StatusCode = (int)apiResult.StatusCode
                };
            }

            return new ObjectResult(apiResult.Result.Value)
            {
                StatusCode = (int)apiResult.StatusCode
            };
        }
    }
}
