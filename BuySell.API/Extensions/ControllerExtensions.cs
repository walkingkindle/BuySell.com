using System.Net;
using System.Text.RegularExpressions;
using BuySellDotCom.Application.Extensions;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BuySell.API.Extensions;

public static class ControllerExtensions
{
    public static IActionResult Match<T>(this ControllerBase controller, ApplicationResult<T> result) where T : class
    {
        if (result.Result.IsSuccess)
        {
            return controller.Ok(result.Result.Value);
        }

        var errorCode = result.Error.ErrorCode;
        return errorCode switch
        {
            "Forbidden" => controller.Forbid(errorCode),
            "NotFound" => controller.NotFound(errorCode),
            "BadRequest" =>
                controller.BadRequest(errorCode),
            _ => controller.Ok(result.Result.Value)
        };
    }
    public static IActionResult Match(this ControllerBase controller, ApplicationResult result)
    {
        if (result.Result.IsSuccess)
        {
            return controller.NoContent();
        }

        var errorCode = result.Error.ErrorCode;
        return errorCode switch
        {
            "Forbidden" => controller.Forbid(errorCode),
            "NotFound" => controller.NotFound(errorCode),
            "BadRequest" =>
                controller.BadRequest(errorCode),
            _ => controller.NoContent()
        };
    }
}



