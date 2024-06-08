using Microsoft.AspNetCore.Mvc;
using Midterm2Ex.Exceptions;
using Midterm2Ex.Services;

namespace Midterm2Ex.Controllers;

[ApiController]
[Route("api/music")]
public class SongsController(IArtistService artistService) : ControllerBase
{
    private readonly IArtistService _artistService = artistService;

    [HttpGet("/artists/{id:int}")]
    public async Task<IActionResult> GetArtistInfoAsync(int id, CancellationToken cancellationToken)
    {
        try
        {
            return Ok(await _artistService.GetArtistInfoByIdAsync(id, cancellationToken));
        }
        catch (ArtistNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}