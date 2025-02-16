namespace Musico.Core.Entities;
public class LikedSong : BaseEntity
{
    public int UserId { get; set; }
    public User? User { get; set; }
    public int SongId { get; set; }
    public Song? Song { get; set; }
    public DateTime LikedAt { get; set; } = DateTime.UtcNow;
}

