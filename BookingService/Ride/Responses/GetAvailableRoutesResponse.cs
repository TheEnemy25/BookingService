namespace BookingService.API.Ride.Responses
{
    public class GetAvailableRoutesResponse
    {
        public IEnumerable<RouteDto> Routes { get; set; }
    }
}
