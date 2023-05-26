using BookingService.Application.Services.Interfaces;
using BookingService.Domain.Dto;
using BookingService.Domain.Repositories;
using BookingService.Domain.Specifications;
using System.Text;
using System.Security.Cryptography;
using Newtonsoft.Json;
using BookingService.Application.Exceptions;

namespace BookingService.Application.Services
{
    public class TicketService : ITicketService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TicketService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<string> GenerateTicket(int userId, RideConfirmationDto rideDto)
        {
            var user = await _unitOfWork.UserRepository.GetSingleAsync(new GetUserWithAllRidesById(userId));
            if (user is null)
                throw new UserNotFoundException(userId);

            var json = JsonConvert.SerializeObject(rideDto);

            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(json);
                var hashBytes = sha256.ComputeHash(bytes);

                var hashPasswordBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(user.Password));

                return $"{Convert.ToBase64String(hashPasswordBytes)}{Convert.ToBase64String(hashBytes)}";
            }
        }

        public Task<bool> IsValid(int userId, string ticket)
        {
            throw new NotImplementedException();
        }

        //public Task<bool> IsValid(int userId, string ticket)
        //{
        //    string passwordHash = ticket.Substring(0, GetPasswordLength(GetUserPassword(userId)));

        //    return Task.FromResult(passwordHash == HashPassword(GetUserPassword(userId)));
        //}

        //private string GetUserPassword(int userId)
        //{
        //    // TODO: Implement logic to get the user's password from the database or any other source
        //    throw new NotImplementedException();
        //}

        //private string HashPassword(string password)
        //{
        //    // TODO: Implement password hashing logic
        //    throw new NotImplementedException();
        //}

        //private string SerializeToJson(object obj)
        //{
        //    // TODO: Implement JSON serialization logic
        //    throw new NotImplementedException();
        //}

        //private int GetPasswordLength(string password)
        //{
        //    // TODO: Implement method to get the appropriate password length
        //    throw new NotImplementedException();
        //}
    }
}
