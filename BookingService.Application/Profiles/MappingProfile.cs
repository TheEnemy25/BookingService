using AutoMapper;
using BookingService.Domain.Dto;
using BookingService.Domain.Entities;
using BookingService.Infrastructure.Entities;

namespace BookingService.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Ride, UserRideDto>();

            CreateMap<User, CreateUserCommand>().ReverseMap();
            CreateMap<User, CreateUserResponseDto>().ReverseMap();

            CreateMap<User, UpdateUserCommand>().ReverseMap();

            CreateMap<RideConfirmationDto, Ride>();
            CreateMap<SeatDto, Seat>().ForMember(x => x.SeatId, y => y.Ignore());
        }
    }
}
