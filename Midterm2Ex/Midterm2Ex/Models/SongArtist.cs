namespace Midterm2Ex.Models;

public class SongArtist
{
    public int IdArtist { get; set; }
    public Artist Artist { get; set; }
    
    public int IdSong { get; set; }
    public Song Song { get; set; }
}