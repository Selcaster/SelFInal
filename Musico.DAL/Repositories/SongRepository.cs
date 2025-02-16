using Musico.Core.Entities;
using Musico.Core.Repositories;
using Musico.DAL.Context;
namespace Musico.DAL.Repositories;

public class SongRepository : GenericRepository<Song>, ISongRepository
{
    public SongRepository(MusicoDbContext _context) : base(_context)
    {
    }
}