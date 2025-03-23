using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAL;

public static class DepInj
{
    public static void AddDAL(this IServiceCollection services, string dbConnection)
    {
        services.AddDbContext<DelovieLiniiContext>(opt => opt.UseSqlServer(dbConnection));
        services.AddScoped<IRepairRecordsRepository, RepairRecordsRepository>();
    }
}
