using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace GagoExampleTest.Models;

public class Reservation
{
    [Key]
    public int IdReservation { get; set; }
    
    [Required]
    public DateTime DateFrom { get; set; }
    
    [Required]
    public DateTime DateTo { get; set; }

    [Required]
    public int Capacity { get; set; }
    
    [Required]
    public int NumOfBoats { get; set; }

    [Required]
    public bool Fulfilled { get; set; }
    
    public int Price { get; set; }

    [MaxLength(200)] 
    public string CancelReason { get; set; } = null!;
    
    public int IdClient { get; set; }

    [ForeignKey(nameof(IdClient))] 
    public Client Client { get; set; } = null!;

    public int IdBoatStandard { get; set; }

    [ForeignKey(nameof(IdBoatStandard))]
    public BoatStandard BoatStandard { get; set; } = null!;

    public ICollection<Sailboat> Sailboats { get; set; } = null!;
}