using AutoMapper;
using BookingService.Domain.Dto;
using BookingService.Domain.Entities;

namespace BookingService.Application.Profiles
{
    public class RideConfirmationDtoToRoute : Profile
    {
        public RideConfirmationDtoToRoute()
        {
            CreateMap<RideConfirmationDto, Route>().ReverseMap();
        }
    }
}
