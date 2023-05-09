using AutoMapper;
using BookingService.Application.Services.Interfaces;
using BookingService.Domain.Dto;
using BookingService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Application.Services
{

    public class UserService : IUserService
    {
        public Task<UserDto> CreateUser(UserDto userDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RideDto>> GetUserRides(int userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUser(UserDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}
