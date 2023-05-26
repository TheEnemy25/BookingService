using AutoMapper;
using BookingService.Domain.Entities;

namespace BookingService.Application.Profiles
{
    public class RouteDtoToRoute : Profile
    {
        public RouteDtoToRoute()
        {
            CreateMap<RouteDto, Route>().ReverseMap();
        }
    }
}
