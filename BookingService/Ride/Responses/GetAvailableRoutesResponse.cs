namespace BookingService.API.Ride.Responses
{
    public class GetAvailableRoutesResponse
    {
        public ICollection<RouteDto> AvailableRoutes { get; set; } = new List<RouteDto>();
    }
}
