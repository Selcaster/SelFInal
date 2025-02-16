namespace Musico.Core.Entities;
public class Album : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public int ArtistId { get; set; }
    public Artist? Artist { get; set; }
    public DateTime ReleaseDate { get; set; }
    public List<Song> Songs { get; set; } = new();
}

