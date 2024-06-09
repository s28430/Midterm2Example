using System.ComponentModel.DataAnnotations;

namespace GagoExampleTest.Models;

public class ClientCategory
{
    [Key]
    public int IdClientCategory { get; set; }

    [Required] 
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [Required]
    public int DiscountPerk { get; set; }

    public ICollection<Client> Clients { get; set; } = null!;
}