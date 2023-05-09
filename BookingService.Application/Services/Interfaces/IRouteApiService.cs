using BookingService.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Application.Services.Interfaces
{
    public interface IRouteApiService
    {
        public Task<IEnumerable<RouteDto>> GetAvailableRoutesAsync(RouteSearchParamsDto routeSearchParams);
        Task<RideConfirmationDto> BookRideAsync(BookRideParamsDto bookRideParams);
        Task<RouteDto> GetRouteByIdAsync(int routeId);
    }
}
