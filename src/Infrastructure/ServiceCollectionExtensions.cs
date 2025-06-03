using GMAO.Domain.Interfaces;
using GMAO.Infrastructure.Data;
using GMAO.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GMAO.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<GMAODbContext>(opt => opt.UseSqlServer(connectionString));
        services.AddScoped<IAssetRepository, AssetRepository>();
        services.AddScoped<IWorkOrderRepository, WorkOrderRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPreventiveMaintenanceRepository, PreventiveMaintenanceRepository>();
        services.AddScoped<IStockRepository, StockRepository>();
        services.AddScoped<ISupplierRepository, SupplierRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
