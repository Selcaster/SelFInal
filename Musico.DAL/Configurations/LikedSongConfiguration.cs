using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Musico.Core.Entities;
namespace Musico.DAL.Configurations;
public class LikedSongConfiguration : IEntityTypeConfiguration<LikedSong>
{
    public void Configure(EntityTypeBuilder<LikedSong> builder)
    {
        builder.HasKey(ls => new { ls.UserId, ls.SongId });

        builder.HasOne(ls => ls.User)
               .WithMany(u => u.LikedSongs)
               .HasForeignKey(ls => ls.UserId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ls => ls.Song)
               .WithMany()
               .HasForeignKey(ls => ls.SongId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
