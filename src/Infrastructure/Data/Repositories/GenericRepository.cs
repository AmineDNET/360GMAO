using GMAO.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GMAO.Infrastructure.Data.Repositories;

public class GenericRepository<T> : IRepository<T> where T : class
{
    protected readonly GMAODbContext _context;
    protected readonly DbSet<T> _dbSet;

    public GenericRepository(GMAODbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public virtual async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => await _dbSet.FindAsync(new object?[] { id }, cancellationToken);

    public virtual async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
    }

    public virtual Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        _dbSet.Update(entity);
        return Task.CompletedTask;
    }
}
