using Midterm2Ex.Models;

namespace Midterm2Ex.Repositories;

public interface ISongRepository
{
    public Task<Song?> GetSongByNameAndDurationAsync(string name, double duration, CancellationToken cancellationToken);

    public Task<int> AddSongAsync(string name, double duration, CancellationToken cancellationToken);

    public Task AddSongToArtistsDiscographyAsync(int idArtist, int idSong, CancellationToken cancellationToken);
}