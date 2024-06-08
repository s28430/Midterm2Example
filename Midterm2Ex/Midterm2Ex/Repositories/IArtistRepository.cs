using Midterm2Ex.Models;

namespace Midterm2Ex.Repositories;

public interface IArtistRepository
{
    public Task<Artist?> GetArtistByIdAsync(int id, CancellationToken cancellationToken);
    public Task<ICollection<Song>> GetSongsOfArtistAsync(int idArtist, CancellationToken cancellationToken);
    public Task<int> AddArtistAsync(string firstName, string lastName, string? pseudonym,
        CancellationToken cancellationToken);
}