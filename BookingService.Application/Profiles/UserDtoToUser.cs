using AutoMapper;
using BookingService.Domain.Dto;
using BookingService.Domain.Entities;

namespace BookingService.Application.Profiles
{
    public class UserDtoToUser : Profile
    {
        public UserDtoToUser()
        {
            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
