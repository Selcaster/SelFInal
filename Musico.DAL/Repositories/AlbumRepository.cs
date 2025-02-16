using Musico.Core.Entities;
using Musico.Core.Repositories;
using Musico.DAL.Context;
namespace Musico.DAL.Repositories;

public class AlbumRepository : GenericRepository<Album>, IAlbumRepository
{
    public AlbumRepository(MusicoDbContext _context) : base(_context)
    {
    }
}