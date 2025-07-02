namespace BuySell.API;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var startup = new Startup(builder.Configuration);

        startup.ConfigureServices(builder.Services, builder.Configuration);

        var app = builder.Build();

        startup.Configure(app, app.Environment);



        app.Run();
    }
}
