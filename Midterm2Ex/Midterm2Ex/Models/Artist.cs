namespace Midterm2Ex.Models;

public class Artist
{
    public int IdArtist { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Pseudonym { get; set; }

    public ICollection<SongArtist> SongArtists { get; set; }
}