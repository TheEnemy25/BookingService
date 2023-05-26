using AutoMapper;
using BookingService.API.Ride.Responses;
using BookingService.Domain.Dto;

namespace BookingService.API.Profiles
{
    public class RideDtoToBookRideResponse : Profile
    {
        public RideDtoToBookRideResponse()
        {
            CreateMap<RideDto, BookRideResponse>();
        }
    }
}
