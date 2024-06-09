using GagoExampleTest.Models;

namespace GagoExampleTest.Repositories;

public interface IReservationRepository
{
    public Task<ICollection<Reservation>> GetReservationsOfClientAsync(int idClient, 
        CancellationToken cancellationToken);
}