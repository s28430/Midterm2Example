namespace Midterm2Ex.Dtos;

public class ArtistDto
{
    public int IdArtist { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Pseudonym { get; set; }
}