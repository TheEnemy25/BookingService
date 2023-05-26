using BookingService.Application.Services.Interfaces;
using BookingService.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Application.Services
{
    public class TicketService : ITicketService
    {
        public Task<string> GenerateTicket(int userId, RideConfirmationDto rideDto)
        {
            string passwordHash = HashPassword(GetUserPassword(userId));
            string rideDtoJson = SerializeToJson(rideDto);
            string ticketCode = passwordHash + rideDtoJson;

            return Task.FromResult(ticketCode);
        }

        public Task<bool> IsValid(int userId, string ticket)
        {
            string passwordHash = ticket.Substring(0, GetPasswordLength(GetUserPassword(userId)));

            return Task.FromResult(passwordHash == HashPassword(GetUserPassword(userId)));
        }

        private string GetUserPassword(int userId)
        {
            // TODO: Implement logic to get the user's password from the database or any other source
            throw new NotImplementedException();
        }

        private string HashPassword(string password)
        {
            // TODO: Implement password hashing logic
            throw new NotImplementedException();
        }

        private string SerializeToJson(object obj)
        {
            // TODO: Implement JSON serialization logic
            throw new NotImplementedException();
        }

        private int GetPasswordLength(string password)
        {
            // TODO: Implement method to get the appropriate password length
            throw new NotImplementedException();
        }
    }
}
