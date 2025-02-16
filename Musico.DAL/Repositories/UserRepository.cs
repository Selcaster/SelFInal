using Musico.Core.Entities;
using Musico.Core.Repositories;
using Musico.DAL.Context;
namespace Musico.DAL.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(MusicoDbContext _context) : base(_context)
    {
    }
}