using Microsoft.EntityFrameworkCore;
using Midterm2Ex.Context;
using Midterm2Ex.Models;

namespace Midterm2Ex.Repositories;

public class ArtistRepository(SongsDbContext dbContext) : IArtistRepository
{
    private readonly SongsDbContext _dbContext = dbContext;
    
    public async Task<Artist?> GetArtistByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _dbContext
            .Artists
            .Where(a => a.IdArtist == id)
            .SingleOrDefaultAsync(cancellationToken);
    }

    public async Task<ICollection<Song>> GetSongsOfArtistAsync(int idArtist, CancellationToken cancellationToken)
    {
        return await _dbContext
            .SongArtists
            .Where(sa => sa.IdArtist == idArtist)
            .Select(sa => sa.Song)
            .ToListAsync(cancellationToken);
    }
}