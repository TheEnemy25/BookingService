using BookingService.Domain.Dto;

namespace BookingService.Application.Services.Interfaces
{
    public interface ITicketService
    {
        Task<string> GenerateTicket(int userId, RideConfirmationDto rideDto);
        Task<bool> IsValid(int userId, string ticket);
    }
}
