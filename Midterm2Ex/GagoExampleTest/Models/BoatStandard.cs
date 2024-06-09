using System.ComponentModel.DataAnnotations;

namespace GagoExampleTest.Models;

public class BoatStandard
{
    [Key]
    public int IdBoatStandard { get; set; }

    [Required] 
    [MaxLength(200)]
    public string Name { get; set; } = null!;

    [Required]
    public int Level { get; set; }

    public ICollection<Reservation> Reservations { get; set; } = null!;
    
    public ICollection<Sailboat> Sailboats { get; set; } = null!;
}