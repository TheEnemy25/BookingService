using AutoMapper;
using BookingService.API.User.Requests;
using BookingService.Domain.Dto;

namespace BookingService.API.Profiles
{
    public class UpdateUserRequestToUserDto : Profile
    {
        public UpdateUserRequestToUserDto()
        {
            CreateMap<UpdateUserRequest, UserDto>();
        }
    }
}
