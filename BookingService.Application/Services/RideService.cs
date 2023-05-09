using BookingService.Application.Services.Interfaces;
using BookingService.Domain.Dto;
using BookingService.Domain.Repositories;
using BookingService.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Application.Services
{
    public class RideService
    {
        private readonly IRouteApiService _routeApiService;
        private readonly ITicketService _ticketService;
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;

        public RideService(IRouteApiService routeApiService, ITicketService ticketService, IUserService userService, IUnitOfWork unitOfWork)
        {
            _routeApiService = routeApiService;
            _ticketService = ticketService;
            _userService = userService;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<RouteDto>> GetAvailableRoutesAsync(RouteSearchParamsDto routeSearchParamsDto)
        {
            return await _routeApiService.GetAvailableRoutesAsync(routeSearchParamsDto);
        }

        public async Task<RideDto> BookRideAsync(int userId, BookRideParamsDto bookRideParamsDto)
        {
            var user = await _userService.GetUserById(userId);
            if (user == null)
            {
                throw new ArgumentException($"User with id {userId} not found");
            }

            var route = await _routeApiService.GetRouteByIdAsync(bookRideParamsDto.RouteId);
            if (route == null)
            {
                throw new ArgumentException($"Route with id {bookRideParamsDto.RouteId} not found");
            }   

            // Make a request to TicketService to generate ticket code
            var ticketCode = await _ticketService.GenerateTicketCodeAsync();

            // Create a new Ride
            var ride = new RideDto
            {
                UserId = user.Id,
                RouteId = route.Id,
                TicketCode = ticketCode
            };

            // Add the Ride to the User's rides
            user.Rides.Add(ride);

            // Update the User in the database
            await _userService.UpdateUser(user);

            // Save changes to the database
            await _unitOfWork.SaveChangesAsync();

            return ride;
        }
    }
}
