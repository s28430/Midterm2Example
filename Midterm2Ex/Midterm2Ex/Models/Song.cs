namespace Midterm2Ex.Models;

public class Song
{
    public int IdSong { get; set; }
    public string SongName { get; set; } = null!;
    public double Duration { get; set; }

    public int? IdAlbum { get; set; }
    public Album? Album { get; set; }

    public ICollection<SongArtist> SongArtists { get; set; }
}