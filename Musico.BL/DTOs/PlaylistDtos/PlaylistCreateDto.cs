namespace Musico.BL.DTOs
{
    public class PlaylistCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public int UserId { get; set; }  // The owner of the playlist
    }
}
