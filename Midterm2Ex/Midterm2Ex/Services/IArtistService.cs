using Midterm2Ex.Dtos;

namespace Midterm2Ex.Services;

public interface IArtistService
{
    public Task<GetArtistInfoResponseDto> GetArtistInfoByIdAsync(int id, CancellationToken cancellationToken);

    public Task<int> AddArtistAsync(AddArtistRequestDto data, CancellationToken cancellationToken);
}