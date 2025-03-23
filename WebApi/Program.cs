using System.Text.Json.Serialization;
using DAL;
using Services;

namespace WebApi;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;

        builder.Services.AddDAL(connectionString);
        builder.Services.AddServices();
        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });;

        string myAllowSpecificOrigins = "_myAllowSpecificOrigins";
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(myAllowSpecificOrigins,
                o =>
                {
                        o.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });

        var app = builder.Build();

        app.UseCors(myAllowSpecificOrigins);
        
        app.MapControllers();

        app.Run();
    }
}