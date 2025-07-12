using CSharpFunctionalExtensions;

namespace BuySellDotCom.Application.Extensions
{
    public class ApplicationResult
    {
        public Result Result { get; }

        public Error Error { get; }


        public ApplicationResult(Result result, Error error)
        {
            Result = result;

            Error = error;
        }

        public static ApplicationResult Failure(Error error) =>
            new(CSharpFunctionalExtensions.Result.Failure(error.Description),error);

        public static ApplicationResult Success() => new(Result.Success(), Error.None);

    }

    public class ApplicationResult<T> where T : class
    {
        public Result<T> Result { get; }

        public Error Error { get; }


        public ApplicationResult(Result<T> result, Error error)
        {
            Result = result;

            Error = error;
        }

        public static ApplicationResult<T> Failure(Error error)=>
            new(CSharpFunctionalExtensions.Result.Failure<T>(error.Description), error);

        public static ApplicationResult<T> Success(T value) =>
            new(CSharpFunctionalExtensions.Result.Success(value), Error.None);
    }
}
