using System.ComponentModel.DataAnnotations;

namespace GagoExampleTest.Dtos;

public class ClientDto
{
    public int IdClient { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;
    
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = null!;

    [Required]
    public DateTime BirthDate { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Pesel { get; set; } = null!;
    
    [Required]
    [MaxLength(100)]
    public string Email { get; set; } = null!;

    [Required]
    public ClientCategoryDto ClientCategoryDto { get; set; } = null!;
}