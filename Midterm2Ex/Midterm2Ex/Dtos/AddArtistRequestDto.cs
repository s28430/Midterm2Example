using System.ComponentModel.DataAnnotations;

namespace Midterm2Ex.Dtos;

public class AddArtistRequestDto
{
    [Required]
    public string ArtistFirstName { get; set; } = null!;
    
    [Required]
    public string ArtistLastName { get; set; } = null!;

    public string? ArtistPseudonym { get; set; }
    
    public SongDto? SongDto { get; set; } = null!;
}