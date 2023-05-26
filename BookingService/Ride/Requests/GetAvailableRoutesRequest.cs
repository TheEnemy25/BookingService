namespace BookingService.API.Ride.Requests
{
    public class GetAvailableRoutesRequest
    {
        public DateTime DepartureDate { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
    }
}
