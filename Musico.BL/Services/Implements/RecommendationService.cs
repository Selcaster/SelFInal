using Musico.Core.Entities;
using Musico.DAL.Repositories;
using Musico.BL.DTOs;
using Musico.Core.Repositories;

namespace Musico.BL.Services;

public class RecommendationService : IRecommendationService
{
    private readonly IGenericRepository<LikedSong> _likedSongRepository;
    private readonly IGenericRepository<Song> _songRepository;

    public RecommendationService(IGenericRepository<LikedSong> likedSongRepository,
                                 IGenericRepository<Song> songRepository)
    {
        _likedSongRepository = likedSongRepository;
        _songRepository = songRepository;
    }

    public async Task<IEnumerable<SongGetDto>> GetRecommendedSongsAsync(int userId)
    {
        // Get the user's liked songs
        var likedSongs = await _likedSongRepository.GetWhereAsync(l => l.UserId == userId);
        var likedSongIds = likedSongs.Select(l => l.SongId).ToList();

        if (!likedSongIds.Any())
            return new List<SongGetDto>(); // No recommendations if no liked songs

        // Get songs by the same artists as liked songs
        var recommendedSongs = await _songRepository.GetWhereAsync(s => likedSongIds.Contains(s.Id) ||
                                                                        likedSongs.Any(l => l.Song.ArtistId == s.ArtistId));

        // Return recommendations
        return recommendedSongs.Select(s => new SongGetDto
        {
            Id = s.Id,
            Title = s.Title
        });
    }
}
