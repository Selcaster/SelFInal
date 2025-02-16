using Musico.Core.Entities;
using Musico.Core.Repositories;
using Musico.DAL.Context;
namespace Musico.DAL.Repositories;

public class PlaylistRepository : GenericRepository<Playlist>, IPlaylistRepository
{
    public PlaylistRepository(MusicoDbContext _context) : base(_context)
    {
    }
}