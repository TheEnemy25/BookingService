using AutoMapper;
using BookingService.API.User.Responses;
using BookingService.Domain.Dto;

namespace BookingService.API.Profiles
{
    public class UserDtoToUserResponse : Profile
    {
        public UserDtoToUserResponse()
        {
            CreateMap<UserDto, UserResponse>();
        }
    }
}
