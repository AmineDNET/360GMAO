using GMAO.Domain.Entities;
using GMAO.Domain.Interfaces;

namespace GMAO.Infrastructure.Data.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(GMAODbContext context) : base(context)
    {
    }
}
