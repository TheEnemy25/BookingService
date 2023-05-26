using AutoMapper;
using BookingService.API.Ride.Requests;
using BookingService.Domain.Dto;

namespace BookingService.API.Profiles
{
    public class BookRideRequestToRideDto : Profile
    {
        public BookRideRequestToRideDto()
        {
            CreateMap<BookRideRequest, RideDto>();
        }
    }
}
