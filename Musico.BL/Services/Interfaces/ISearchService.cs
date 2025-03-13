using Musico.BL.DTOs;

namespace Musico.BL.Services;

public interface ISearchService
{
    Task<IEnumerable<SongGetDto>> SearchSongsAsync(string query);
    Task<IEnumerable<ArtistGetDto>> SearchArtistsAsync(string query);
    Task<IEnumerable<PlaylistGetDto>> SearchPlaylistsAsync(string query);
}