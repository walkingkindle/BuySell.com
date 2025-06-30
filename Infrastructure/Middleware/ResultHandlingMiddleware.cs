using System.Text.Json;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Middleware
{
    public class ResultHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ResultHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var originalBodyStream = context.Response.Body;
            using var memoryStream = new MemoryStream();
            context.Response.Body = memoryStream;

            await _next(context);

            memoryStream.Seek(0, SeekOrigin.Begin);
            var responseBody = await new StreamReader(memoryStream).ReadToEndAsync();

            memoryStream.Seek(0, SeekOrigin.Begin);
            await memoryStream.CopyToAsync(originalBodyStream);

            if (context.Response.ContentType?.Contains("application/json") == true)
            {
                try
                {
                    var result = JsonSerializer.Deserialize<Result<object>>(responseBody, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (result is { IsFailure: true })
                    {
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        await context.Response.WriteAsync(result.Error ?? "Bad request");
                    }
                    else if (result is { IsSuccess: true, Value: null })
                    {
                        context.Response.StatusCode = StatusCodes.Status204NoContent;
                    }
                }
                catch
                {
                    // Ignore if not a Result<T> JSON
                }
            }

        }
    }
}
