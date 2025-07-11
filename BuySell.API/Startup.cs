using BuySellDotCom.Application.Interfaces.Repositories;
using BuySellDotCom.Application.Interfaces.Services;
using BuySellDotCom.Application.Services;
using Infrastructure;
using Infrastructure.Context;
using Infrastructure.Middleware;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace BuySell.API;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BuySellDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Database")));

        Log.Logger = new LoggerConfiguration()
        .CreateLogger();

        //repos
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IListingRepository, ListingRepository>();

        services.AddScoped<IAddressRepository, AddressRepository>();

        services.AddScoped<IReviewRepository, ReviewRepository>();


        //services

        services.AddTransient<IAddressService, AddressService>();

        services.AddTransient<IListingService, ListingService>();

        services.AddTransient<IUserService, UserService>();

        services.AddTransient<IReviewService, ReviewService>();

        //miscellaneous

        services.AddControllers(); 

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddAutoMapper(typeof(MappingProfile));


    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseExceptionHandler(err =>
        {
            err.Run(async context =>
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                var problemDetails = new
                {
                    type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                    title = "An unexpected error occurred!",
                    status = 500,
                    detail = "An internal server error has occurred."
                };

                Log.Error("An unhandled exception occurred: {Message}", context.Features.Get<IExceptionHandlerFeature>()?.Error.Message);
                await context.Response.WriteAsJsonAsync(problemDetails);
            });
        });

        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}

