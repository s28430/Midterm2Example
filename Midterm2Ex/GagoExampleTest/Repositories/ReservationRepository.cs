using GagoExampleTest.Context;
using GagoExampleTest.Models;
using Microsoft.EntityFrameworkCore;

namespace GagoExampleTest.Repositories;

public class ReservationRepository(BoatsDbContext dbContext) : IReservationRepository
{
    private readonly BoatsDbContext _dbContext = dbContext;

    public async Task<ICollection<Reservation>> GetReservationsOfClientAsync(int idClient, CancellationToken cancellationToken)
    {
        return await _dbContext
            .Reservations
            .Where(r => r.IdClient == idClient)
            .ToListAsync(cancellationToken);
    }
}