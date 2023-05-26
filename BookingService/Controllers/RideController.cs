using BookingService.API.Ride.Requests;
using BookingService.API.Ride.Responses;
using BookingService.Application.Services.Interfaces;
using BookingService.Domain.Dto;
using BookingService.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.API.Controllers
{
    [ApiController]
    [Route("api/rides")]
    public class RideController : ControllerBase
    {
        private readonly IRideService _rideService;
        private readonly ITicketService _ticketService;

        public RideController(IRideService rideService, ITicketService ticketService)
        {
            _rideService = rideService;
            _ticketService = ticketService;
        }

        [HttpGet("available")]
        public async Task<ActionResult<GetAvailableRoutesResponse>> GetAvailableRoutes([FromQuery] GetAvailableRoutesRequest request)
        {
            var searchParams = new RouteSearchParamsDto
            {
                From = request.DepartureCity,
                To = request.ArrivalCity,
                DepartureTime = request.DepartureDate,
            };

            var availableRoutes = await _rideService.GetAvailableRoutesAsync(searchParams);

            var response = new GetAvailableRoutesResponse
            {
                Routes = availableRoutes
            };

            return Ok(response);
        }

        [HttpPost("{userId}/book")]
        public async Task<ActionResult<BookRideResponse>> BookRide(int userId, [FromBody] BookRideRequest request)
        {
            var rideDto = new RideConfirmationDto
            {
                RouteId = request.RouteId
                // інші властивості 
            };

            var ticketCode = await _ticketService.GenerateTicket(userId, rideDto);

            var response = new BookRideResponse
            {
                TicketCode = ticketCode
                // інші властивості
            };

            return Ok(response);
        }

        [HttpGet("{userId}/validate-ticket")]
        public async Task<ActionResult<bool>> ValidateTicketCode(int userId, [FromQuery] string ticketCode)
        {
            var isValid = await _ticketService.IsValid(userId, ticketCode);
            return Ok(isValid);
        }
    }
}
