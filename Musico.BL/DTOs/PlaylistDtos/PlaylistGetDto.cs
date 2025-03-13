namespace Musico.BL.DTOs
{
    public class PlaylistGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public UserGetDto User { get; set; }  // Owner of the playlist
        public ICollection<SongGetDto> Songs { get; set; } = new List<SongGetDto>(); // Nested DTO
    }
}
