using BookingService.Domain.Dto;

namespace BookingService.Application.Services.Interfaces
{
    public interface IRideService
    {
        Task<ICollection<RouteDto>> GetAvailableRoutesAsync(RouteSearchParamsDto routeSearchParamsDto);
        Task<RideDto> BookRideAsync(int userId, BookRideParamsDto bookRideParamsDto);
    }
}
