﻿using Musico.Core.Entities;
using Musico.Core.Repositories;
using Musico.DAL.Context;
namespace Musico.DAL.Repositories;

public class PlaylistSongRepository : GenericRepository<PlaylistSong>, IPlaylistSongRepository
{
    public PlaylistSongRepository(MusicoDbContext _context) : base(_context)
    {
    }
}