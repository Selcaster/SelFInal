namespace Musico.Core.Entities;
public class Playlist : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public int UserId { get; set; }
    public User? User { get; set; }
    public List<PlaylistSong> PlaylistSongs { get; set; } = new();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
