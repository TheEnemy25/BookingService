using BookingService.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Application.Services.Interfaces
{
    public interface ITicketService
    {
        Task<string> GenerateTicket(int userId, RideConfirmationDto rideDto);
        Task<bool> IsValid(int userId, string ticket);
    }
}
