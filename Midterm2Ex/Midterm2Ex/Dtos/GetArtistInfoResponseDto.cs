using System.ComponentModel.DataAnnotations;

namespace Midterm2Ex.Dtos;

public class GetArtistInfoResponseDto
{
    [Required]
    public ArtistDto Artist { get; set; } = null!;

    [Required]
    public ICollection<SongDto> Songs { get; set; } = null!;
}