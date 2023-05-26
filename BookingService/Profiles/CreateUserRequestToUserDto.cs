using AutoMapper;
using BookingService.API.User.Requests;
using BookingService.Domain.Dto;

namespace BookingService.API.Profiles
{
    public class CreateUserRequestToUserDto : Profile
    {
        public CreateUserRequestToUserDto()
        {
            CreateMap<CreateUserRequest, UserDto>();
        }
    }
}
