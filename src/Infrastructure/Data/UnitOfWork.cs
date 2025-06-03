using GMAO.Domain.Interfaces;

namespace GMAO.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly GMAODbContext _context;

    public UnitOfWork(GMAODbContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => await _context.SaveChangesAsync(cancellationToken);
}
