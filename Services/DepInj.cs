using Microsoft.Extensions.DependencyInjection;

namespace Services;

public static class DepInj
{
    public static void AddServices(this IServiceCollection services) 
    {
        services.AddScoped<IRepairsService, RepairsService>();   
    }
}
