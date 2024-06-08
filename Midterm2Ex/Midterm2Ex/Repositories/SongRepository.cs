using Microsoft.EntityFrameworkCore;
using Midterm2Ex.Context;
using Midterm2Ex.Models;

namespace Midterm2Ex.Repositories;

public class SongRepository(SongsDbContext dbContext) : ISongRepository
{
    private readonly SongsDbContext _dbContext = dbContext;
    
    public async Task<Song?> GetSongByNameAndDurationAsync(string name, double duration, CancellationToken cancellationToken)
    {
        return await _dbContext
            .Songs
            .Where(s => s.SongName == name && Math.Abs(s.Duration - duration) < 0.2)
            .SingleOrDefaultAsync(cancellationToken);
    }

    public async Task<int> AddSongAsync(string name, double duration, CancellationToken cancellationToken)
    {
        var song = new Song
        {
            SongName = name,
            Duration = duration
        };
        await _dbContext.Songs.AddAsync(song, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return song.IdSong;
    }

    public async Task AddSongToArtistsDiscographyAsync(int idArtist, int idSong, CancellationToken cancellationToken)
    {
        var sa = new SongArtist
        {
            IdArtist = idArtist,
            IdSong = idSong
        };
        await _dbContext.SongArtists.AddAsync(sa, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}