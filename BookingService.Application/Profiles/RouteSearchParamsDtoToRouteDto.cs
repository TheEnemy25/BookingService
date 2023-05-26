using AutoMapper;
using BookingService.Domain.Dto;

namespace BookingService.Application.Profiles
{
    public class RouteSearchParamsDtoToRouteDto : Profile
    {
        public RouteSearchParamsDtoToRouteDto()
        {
            CreateMap<RouteSearchParamsDto, RouteDto>().ReverseMap();
        }
    }
}
