using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Musico.Core.Entities;
namespace Musico.DAL.Configurations;
public class SongConfiguration : IEntityTypeConfiguration<Song>
{
    public void Configure(EntityTypeBuilder<Song> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Title).IsRequired().HasMaxLength(255);
        builder.HasOne(s => s.Artist)
               .WithMany(a => a.Songs)
               .HasForeignKey(s => s.ArtistId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
