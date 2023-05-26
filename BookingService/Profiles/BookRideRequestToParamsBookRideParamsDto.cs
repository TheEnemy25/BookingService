using BookingService.API.Ride.Requests;
using AutoMapper;
using BookingService.Domain.Dto;

namespace BookingService.API.Profiles
{
    public class BookRideRequestToParamsBookRideParamsDto : Profile
    {
        public BookRideRequestToParamsBookRideParamsDto()
        {
            CreateMap<BookRideRequest, BookRideParamsDto>();
        }
    }
}
