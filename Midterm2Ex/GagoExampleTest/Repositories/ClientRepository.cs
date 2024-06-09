using GagoExampleTest.Context;
using GagoExampleTest.Models;
using Microsoft.EntityFrameworkCore;

namespace GagoExampleTest.Repositories;

public class ClientRepository(BoatsDbContext dbContext) : IClientRepository
{
    private readonly BoatsDbContext _dbContext = dbContext;
    
    public async Task<Client?> GetClientByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _dbContext
            .Clients
            .Where(c => c.IdClient == id)
            .Include(c => c.ClientCategory)
            .SingleOrDefaultAsync(cancellationToken);
    }
}