﻿using BookingService.Application.Features.Rides.Commands.BookRide;
using BookingService.Application.Features.Rides.Queries.GeAvailableRoutes;

namespace BookingService.Application.Interfaces.Services.Infrastructure
{
    public interface IRouteApiService
    {
        Task<IEnumerable<RouteDto>?> GetAvailableRoutesAsync(GetAvailableRoutesQuery routeSearchParams);
        Task<RideConfirmationDto> BookRideAsync(BookRideCommand bookRideQuery);
    }
}