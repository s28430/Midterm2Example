namespace GagoExampleTest.Dtos;

public class GetClientsReservationInfoResponseDto
{
    public ClientDto Client { get; set; } = null!;

    public ICollection<ReservationDto> ReservationDtos { get; set; } = null!;
}