using GagoExampleTest.Exceptions;
using GagoExampleTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace GagoExampleTest.Controllers;

[ApiController]
[Route("/api/boats")]
public class BoatsController(IClientService clientService) : ControllerBase
{
    private readonly IClientService _clientService = clientService;

    [HttpGet("/clients/{id:int}/reservations")]
    public async Task<IActionResult> GetClientsReservationsAsync(int id, CancellationToken cancellationToken)
    {
        try
        {
            return Ok(await _clientService.GetClientsReservationsAsync(id, cancellationToken));
        }
        catch (ClientNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}