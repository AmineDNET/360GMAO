using GMAO.Domain.Entities;
using GMAO.Domain.Interfaces;

namespace GMAO.Infrastructure.Data.Repositories;

public class AssetRepository : GenericRepository<Asset>, IAssetRepository
{
    public AssetRepository(GMAODbContext context) : base(context)
    {
    }
}
