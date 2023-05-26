namespace BookingService.API.Ride.Requests
{
    public class GetAvailableRoutesRequest
    {
        public DateTime DepartureDate { get; set; }
        public string From { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
    }
}
