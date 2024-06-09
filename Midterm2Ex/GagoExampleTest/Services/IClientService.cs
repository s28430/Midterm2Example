using GagoExampleTest.Dtos;

namespace GagoExampleTest.Services;

public interface IClientService
{
    public Task<GetClientsReservationInfoResponseDto> GetClientsReservationsAsync(int idClient,
        CancellationToken cancellationToken);
}