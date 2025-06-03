using GMAO.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GMAO.Infrastructure.Data;

public class GMAODbContext : DbContext
{
    public GMAODbContext(DbContextOptions<GMAODbContext> options) : base(options)
    {
    }

    public DbSet<Asset> Assets => Set<Asset>();
    public DbSet<User> Users => Set<User>();
    public DbSet<WorkOrder> WorkOrders => Set<WorkOrder>();
    public DbSet<PreventiveMaintenance> PreventiveMaintenances => Set<PreventiveMaintenance>();
    public DbSet<StockItem> StockItems => Set<StockItem>();
    public DbSet<Supplier> Suppliers => Set<Supplier>();
}
