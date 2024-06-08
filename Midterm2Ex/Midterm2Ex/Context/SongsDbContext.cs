using Microsoft.EntityFrameworkCore;
using Midterm2Ex.Models;

namespace Midterm2Ex.Context;

public class SongsDbContext : DbContext
{
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Song> Songs { get; set; }
    public DbSet<SongArtist> SongArtists { get; set; }
    public DbSet<Studio> Studios { get; set; }
    public DbSet<Album> Albums { get; set; }
    
    
    protected SongsDbContext()
    {
    }

    public SongsDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // configuring artist model
        modelBuilder
            .Entity<Artist>()
            .HasKey(a => a.IdArtist);
        
        modelBuilder
            .Entity<Artist>()
            .Property(a => a.FirstName)
            .HasMaxLength(30)
            .IsRequired();
        
        modelBuilder
            .Entity<Artist>()
            .Property(a => a.LastName)
            .HasMaxLength(40)
            .IsRequired();
        
        modelBuilder
            .Entity<Artist>()
            .Property(a => a.Pseudonym)
            .HasMaxLength(50)
            .IsRequired(false);
        
        // configuring song model
        modelBuilder
            .Entity<Song>()
            .HasKey(s => s.IdSong);
        
        modelBuilder
            .Entity<Song>()
            .Property(s => s.SongName)
            .HasMaxLength(30)
            .IsRequired();

        modelBuilder
            .Entity<Song>()
            .Property(s => s.Duration)
            .IsRequired();

        modelBuilder
            .Entity<Song>()
            .HasOne(s => s.Album)
            .WithMany(a => a.Songs)
            .HasForeignKey(s => s.IdAlbum);

        // configuring song artists model
        modelBuilder
            .Entity<SongArtist>()
            .HasKey(sa => new { sa.IdArtist, sa.IdSong });
        
        modelBuilder
            .Entity<SongArtist>()
            .HasOne(sa => sa.Artist)
            .WithMany(a => a.SongArtists)
            .HasForeignKey(sa => sa.IdArtist);
        
        modelBuilder
            .Entity<SongArtist>()
            .HasOne(sa => sa.Song)
            .WithMany(s => s.SongArtists)
            .HasForeignKey(sa => sa.IdSong);
        
        // configuring studio model
        modelBuilder
            .Entity<Studio>()
            .HasKey(s => s.IdStudio);

        modelBuilder
            .Entity<Studio>()
            .Property(s => s.Name)
            .HasMaxLength(50)
            .IsRequired();
        
        // configuring album model
        modelBuilder
            .Entity<Album>()
            .HasKey(a => a.IdAlbum);

        modelBuilder
            .Entity<Album>()
            .Property(a => a.Name)
            .HasMaxLength(30)
            .IsRequired();
        
        modelBuilder
            .Entity<Album>()
            .Property(a => a.ReleaseDate)
            .IsRequired();

        modelBuilder
            .Entity<Album>()
            .HasOne(a => a.Studio)
            .WithMany(s => s.Albums)
            .HasForeignKey(a => a.IdAlbum);
    }
}