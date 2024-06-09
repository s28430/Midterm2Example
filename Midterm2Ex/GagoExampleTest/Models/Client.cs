using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GagoExampleTest.Models;

public class Client
{
    [Key]
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

    public int IdClientCategory { get; set; }

    [ForeignKey(nameof(IdClientCategory))]
    public ClientCategory ClientCategory { get; set; } = null!;
}