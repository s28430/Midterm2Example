using Midterm2Ex.Dtos;
using Midterm2Ex.Exceptions;
using Midterm2Ex.Repositories;

namespace Midterm2Ex.Services;

public class ArtistService(IArtistRepository artistRepository) : IArtistService
{
    private readonly IArtistRepository _artistRepository = artistRepository;
    
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
}