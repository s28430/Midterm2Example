using GagoExampleTest.Models;

namespace GagoExampleTest.Repositories;

public interface IClientRepository
{
    public Task<Client?> GetClientByIdAsync(int id, CancellationToken cancellationToken);
}