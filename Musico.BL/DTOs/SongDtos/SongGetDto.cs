
namespace Musico.BL.DTOs
{
    public class SongGetDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public TimeSpan Duration { get; set; }
        public ArtistGetDto Artist { get; set; } // Nested Artist DTO
        public AlbumDto? Album { get; set; }  // Nullable for singles
    }
}
