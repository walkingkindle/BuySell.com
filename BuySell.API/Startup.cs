using BuySellDotCom.Application.Interfaces.Repositories;
using BuySellDotCom.Application.Interfaces.Services;
using BuySellDotCom.Application.Services;
using Infrastructure;
using Infrastructure.Context;
using Infrastructure.Middleware;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

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

        services.AddTransient<IListingService, ListingService>();

        services.AddTransient<IUserRepository, UserRepository>();

        services.AddTransient<IListingRepository, ListingRepository>();

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
        app.UseMiddleware<ResultHandlingMiddleware>();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}

