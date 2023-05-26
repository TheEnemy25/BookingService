using AutoMapper;
using BookingService.Domain.Dto;
using BookingService.Domain.Entities;

namespace BookingService.Application.Profiles
{
    public class RideDtoToRoute : Profile
    {
        public RideDtoToRoute()
        {
            CreateMap<RideDto, Route>().ReverseMap();
        }
    }
}
