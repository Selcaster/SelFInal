using Musico.BL.DTOs;
using Musico.Core.Entities;
using Musico.DAL.Repositories;
using Musico.Core.Repositories;

namespace Musico.BL.Services;

public class SearchService : ISearchService
{
    private readonly IGenericRepository<Song> _songRepository;
    private readonly IGenericRepository<Artist> _artistRepository;
    private readonly IGenericRepository<Playlist> _playlistRepository;

    public SearchService(IGenericRepository<Song> songRepository,
                         IGenericRepository<Artist> artistRepository,
                         IGenericRepository<Playlist> playlistRepository)
    {
        _songRepository = songRepository;
        _artistRepository = artistRepository;
        _playlistRepository = playlistRepository;
    }

    public async Task<IEnumerable<SongGetDto>> SearchSongsAsync(string query)
    {
        var songs = await _songRepository.GetWhereAsync(s => s.Title.Contains(query));
        return songs.Select(s => new SongGetDto
        {
            Id = s.Id,
            Title = s.Title
        });
    }

    public async Task<IEnumerable<ArtistGetDto>> SearchArtistsAsync(string query)
    {
        var artists = await _artistRepository.GetWhereAsync(a => a.Name.Contains(query));
        return artists.Select(a => new ArtistGetDto
        {
            Id = a.Id,
            Name = a.Name
        });
    }

    public async Task<IEnumerable<PlaylistGetDto>> SearchPlaylistsAsync(string query)
    {
        var playlists = await _playlistRepository.GetWhereAsync(p => p.Name.Contains(query));
        return playlists.Select(p => new PlaylistGetDto
        {
            Id = p.Id,
            Name = p.Name
        });
    }
}
