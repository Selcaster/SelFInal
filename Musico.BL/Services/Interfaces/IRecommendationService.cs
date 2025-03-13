using Musico.BL.DTOs;

namespace Musico.BL.Services;

public interface IRecommendationService
{
    Task<IEnumerable<SongGetDto>> GetRecommendedSongsAsync(int userId);
}
