using GMAO.Domain.Entities;
using GMAO.Domain.Interfaces;

namespace GMAO.Infrastructure.Data.Repositories;

public class WorkOrderRepository : GenericRepository<WorkOrder>, IWorkOrderRepository
{
    public WorkOrderRepository(GMAODbContext context) : base(context)
    {
    }
}
