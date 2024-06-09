using GagoExampleTest.Dtos;
using GagoExampleTest.Exceptions;
using GagoExampleTest.Models;
using GagoExampleTest.Repositories;

namespace GagoExampleTest.Services;

public class ClientService(IClientRepository clientRepository, IReservationRepository reservationRepository) : IClientService
{
    private readonly IClientRepository _clientRepository = clientRepository;
    private readonly IReservationRepository _reservationRepository = reservationRepository;


    private static GetClientsReservationInfoResponseDto ConstructResponse(ICollection<Reservation> reservations, Client client)
    {
        var reservationDtos = reservations.Select(r => new ReservationDto 
        {
            DateFrom = r.DateFrom,
            DateTo = r.DateTo,
            Capacity = r.Capacity,
            NumOfBoats = r.NumOfBoats,
            Fulfilled = r.Fulfilled,
            Price = r.Price,
            CancelReason = r.CancelReason
        }).ToList();
       
        

        var response = new GetClientsReservationInfoResponseDto()
        {
            Client = new ClientDto
            {
                IdClient = client.IdClient,
                BirthDate = client.BirthDate,
                Email = client.Email,
                LastName = client.LastName,
                Name = client.Name,
                Pesel = client.Pesel,
                ClientCategoryDto = new ClientCategoryDto
                {
                    Name = client.ClientCategory.Name,
                    DiscountPerk = client.ClientCategory.DiscountPerk,
                    IdClientCategory = client.ClientCategory.IdClientCategory
                }
            },
            ReservationDtos = reservationDtos
        };
        return response;
    }
    
    
    public async Task<GetClientsReservationInfoResponseDto> GetClientsReservationsAsync(int idClient,
        CancellationToken cancellationToken)
    {
        var client = await _clientRepository.GetClientByIdAsync(idClient, cancellationToken);

        if (client is null)
        {
            throw new ClientNotFoundException($"Client with id {idClient} does not exist.");
        }

        var reservations = 
            await _reservationRepository.GetReservationsOfClientAsync(idClient, cancellationToken);
        
        var response = ConstructResponse(reservations, client);
        
        return response;
    }
}