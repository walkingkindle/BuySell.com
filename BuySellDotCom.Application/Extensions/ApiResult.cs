using System.Net;
using CSharpFunctionalExtensions;

namespace BuySell.API.Extensions
{
    public class ApiResult
    {
        public Result Result { get; }

        public HttpStatusCode StatusCode { get; }


        public ApiResult(Result result, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            Result = result;

            StatusCode = statusCode;
        }

        public static ApiResult Failure(string error, HttpStatusCode statusCode = HttpStatusCode.BadRequest) =>
            new(CSharpFunctionalExtensions.Result.Failure(error), statusCode);

        public static ApiResult Success() => new(Result.Success(), HttpStatusCode.NoContent);

    }

    public class ApiResult<T> where T : class
    {
        public Result<T> Result { get; }

        public HttpStatusCode StatusCode { get; }


        public ApiResult(Result<T> result, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            Result = result;

            StatusCode = statusCode;
        }

        public static ApiResult<T> Failure(string error, HttpStatusCode statusCode = HttpStatusCode.BadRequest) =>
            new(CSharpFunctionalExtensions.Result.Failure<T>(error), statusCode);

        public static ApiResult<T> Success(T value) =>
            new(CSharpFunctionalExtensions.Result.Success(value), HttpStatusCode.OK);
    }
}
