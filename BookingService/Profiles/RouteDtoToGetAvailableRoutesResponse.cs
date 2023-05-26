using AutoMapper;
using BookingService.API.Ride.Responses;

namespace BookingService.API.Profiles
{
    public class RouteDtoToGetAvailableRoutesResponse : Profile
    {
        public RouteDtoToGetAvailableRoutesResponse()
        {
            CreateMap<ICollection<RouteDto>, GetAvailableRoutesResponse>()
                .ForMember(dest => dest.AvailableRoutes, opt => opt.MapFrom(src => src));
        }
    }
}
