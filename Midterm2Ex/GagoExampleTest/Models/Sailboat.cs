using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GagoExampleTest.Models;

public class Sailboat
{
    [Key]
    public int IdSailboat { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [Required]
    public int Capacity { get; set; }

    [Required]
    [MaxLength(100)]
    public string Description { get; set; } = null!;

    [Required]
    public int Price { get; set; }

    public int IdBoatStandard { get; set; }

    [ForeignKey(nameof(IdBoatStandard))]
    public BoatStandard BoatStandard { get; set; } = null!;

    public ICollection<Reservation> Reservations { get; set; } = null!;
}