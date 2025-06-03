using GMAO.Domain.Entities;
using GMAO.Domain.Interfaces;

namespace GMAO.Infrastructure.Data.Repositories;

public class StockRepository : GenericRepository<StockItem>, IStockRepository
{
    public StockRepository(GMAODbContext context) : base(context)
    {
    }
}
