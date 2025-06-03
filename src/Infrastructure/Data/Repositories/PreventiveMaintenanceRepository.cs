using GMAO.Domain.Entities;
using GMAO.Domain.Interfaces;

namespace GMAO.Infrastructure.Data.Repositories;

public class PreventiveMaintenanceRepository : GenericRepository<PreventiveMaintenance>, IPreventiveMaintenanceRepository
{
    public PreventiveMaintenanceRepository(GMAODbContext context) : base(context)
    {
    }
}
