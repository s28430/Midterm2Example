using System.ComponentModel.DataAnnotations;

namespace GagoExampleTest.Dtos;

public class ClientCategoryDto
{
    public int IdClientCategory { get; set; }

    [Required] 
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [Required]
    public int DiscountPerk { get; set; }
}