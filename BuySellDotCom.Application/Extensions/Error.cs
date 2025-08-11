namespace BuySellDotCom.Application.Extensions
{
    public sealed record Error(string ErrorCode, string Description)
    {
        public static readonly Error None = new(string.Empty, string.Empty);

    }

    public static class Errors
    {
        public static readonly Error NotFound =
            new Error("NotFound", "The resource you requested was not found.");

        public static readonly Error Forbidden =
            new Error("Forbidden","You are not permitted to change or use the resource that was requested.");

        public static Error BadRequest(string description) => new Error("BadRequest",description);
    }
}
