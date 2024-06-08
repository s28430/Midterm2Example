using Midterm2Ex.Context;
using Midterm2Ex.Dtos;
using Midterm2Ex.Exceptions;
using Midterm2Ex.Repositories;

namespace Midterm2Ex.Services;

public class ArtistService(IArtistRepository artistRepository,
    ISongRepository songRepository, SongsDbContext dbContext) 
    : IArtistService
{
    private readonly IArtistRepository _artistRepository = artistRepository;
    private readonly ISongRepository _songRepository = songRepository;
    private readonly SongsDbContext _dbContext = dbContext;
    
    public async Task<GetArtistInfoResponseDto> GetArtistInfoByIdAsync(int id, CancellationToken cancellationToken)
    {
        var artist = await _artistRepository.GetArtistByIdAsync(id, cancellationToken);
        
        if (artist is null)
        {
            throw new ArtistNotFoundException($"Artist with id {id} not found");
        }

        var songs = await _artistRepository.GetSongsOfArtistAsync(id, cancellationToken);

        var songsDtos = songs.Select(s => new SongDto
        {
            IdSong = s.IdSong,
            Duration = s.Duration,
            SongName = s.SongName
        }).ToList();

        return new GetArtistInfoResponseDto
        {
            Artist = new ArtistDto
            {
                FirstName = artist.FirstName,
                IdArtist = artist.IdArtist,
                LastName = artist.LastName,
                Pseudonym = artist.Pseudonym
            },
            Songs = songsDtos
        };
    }

    public async Task<int> AddArtistAsync(AddArtistRequestDto data, CancellationToken cancellationToken)
    {
        await using var transaction = 
            await _dbContext.Database.BeginTransactionAsync(cancellationToken);

        int insertedArtistId;

        try
        {
            insertedArtistId = await _artistRepository.AddArtistAsync(data.ArtistFirstName,
                data.ArtistLastName, data.ArtistPseudonym, cancellationToken);
        
        
            if (data.SongDto is not null)
            {
                var song = await _songRepository.GetSongByNameAndDurationAsync(data.SongDto.SongName,
                    data.SongDto.Duration, cancellationToken);

                int songId;
                if (song is null)
                {
                    songId = await _songRepository.AddSongAsync(data.SongDto.SongName,
                        data.SongDto.Duration, cancellationToken);
                }
                else
                {
                    songId = song.IdSong;
                }

                await _songRepository.AddSongToArtistsDiscographyAsync(insertedArtistId, songId, cancellationToken);
            }
        }
        catch (Exception)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }

        await transaction.CommitAsync(cancellationToken);
        return insertedArtistId;
    }
}