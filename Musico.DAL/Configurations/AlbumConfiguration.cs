using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Musico.Core.Entities;
namespace Musico.DAL.Configurations;
public class AlbumConfiguration : IEntityTypeConfiguration<Album>
{
    public void Configure(EntityTypeBuilder<Album> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Title).IsRequired().HasMaxLength(255);
        builder.HasOne(a => a.Artist)
               .WithMany(art => art.Albums)
               .HasForeignKey(a => a.ArtistId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
