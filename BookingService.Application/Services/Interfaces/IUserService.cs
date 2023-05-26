using BookingService.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> CreateUser(UserDto userDto);
        Task UpdateUser(UserDto userDto);
        Task DeleteUser(int userId);
        Task<UserDto> GetUserById(int userId);
        Task<ICollection<RideDto>> GetUserRides(int userId);
    }
}
