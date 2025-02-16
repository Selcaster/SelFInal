using Musico.Core.Entities;

namespace Musico.BL.DTOs
{
    public class ArtistGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<AlbumDto> Albums { get; set; } = new List<AlbumDto>(); // Nested DTO
    }

    public class AlbumDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}
