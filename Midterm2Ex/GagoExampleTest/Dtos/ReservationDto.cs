using System.ComponentModel.DataAnnotations;

namespace GagoExampleTest.Dtos;

public class ReservationDto
{
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
}