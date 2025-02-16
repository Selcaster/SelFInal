namespace Musico.Core.Entities;
public class Song: BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public int ArtistId { get; set; }
    public Artist? Artist { get; set; }
    public Album? Album { get; set; }
    public Genre Genre { get; set; }
    public int DurationInSeconds { get; set; } // Song length in seconds
    public DateTime ReleaseDate { get; set; }
}

