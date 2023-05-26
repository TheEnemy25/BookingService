using AutoMapper;
using BookingService.Application.Services.Interfaces;
using BookingService.Domain.Dto;
using BookingService.Domain.Entities;
using BookingService.Domain.Repositories;
using BookingService.Infrastructure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Application.Services
{
    public class RideService : IRideService
    {
        private readonly IMapper _mapper;
        private readonly IRouteApiService _routeApiService;
        private readonly ITicketService _ticketService;
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;

        public RideService(
        IMapper mapper,
        IRouteApiService routeApiService,
        ITicketService ticketService,
        IUserService userService,
        IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _routeApiService = routeApiService;
            _ticketService = ticketService;
            _userService = userService;
            _unitOfWork = unitOfWork;
        }

        public async Task<ICollection<RouteDto>> GetAvailableRoutesAsync(RouteSearchParamsDto routeSearchParamsDto)
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

            var rideConfirmationDto = new RideConfirmationDto
            {
                RouteId = route.Id.ToString()
            };

            var ticketCode = await _ticketService.GenerateTicket(userId, rideConfirmationDto);

            var rideDto = new RideDto
            {
                UserId = user.Id,
                RouteId = route.Id,
                TicketCode = ticketCode
            };

            user.Rides.Add(rideDto);

            await _userService.UpdateUser(user);
            await _unitOfWork.SaveChangesAsync();

            return rideDto;
        }
    }
}