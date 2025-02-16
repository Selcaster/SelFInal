namespace Musico.BL.DTOs
{
    public class SongCreateDto
    {
        public string Title { get; set; } = string.Empty;
        public int ArtistId { get; set; } // Reference to the artist
        public int AlbumId { get; set; }  // Reference to the album (optional)
        public TimeSpan Duration { get; set; }  // Song length
    }
}
