using Musico.Core.Entities;
using Musico.Core.Repositories;
using Musico.DAL.Context;
namespace Musico.DAL.Repositories;

public class LikedSongRepository : GenericRepository<LikedSong>, ILikedSongRepository
{
    public LikedSongRepository(MusicoDbContext _context) : base(_context)
    {
    }
}