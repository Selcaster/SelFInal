using Musico.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace Musico.DAL.Context;

public class MusicoDbContext : DbContext
{
    public MusicoDbContext(DbContextOptions<MusicoDbContext> options) : base(options)
    {
    }
    public DbSet<Song> Songs { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<PlaylistSong> PlaylistSongs { get; set; }
    public DbSet<LikedSong> LikedSongs { get; set; }
    public DbSet<Playlist> Playlists { get; set; }
    public DbSet<Album> Albums { get; set; }
    public DbSet<Artist> Artists { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MusicoDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries<BaseEntity>();
        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedTime = DateTime.UtcNow;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}