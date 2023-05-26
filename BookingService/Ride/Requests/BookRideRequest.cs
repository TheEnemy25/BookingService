namespace BookingService.API.Ride.Requests
{
    public class BookRideRequest
    {
        public int UserId { get; set; }
        public string RouteId { get; set; }
        public string TicketCode { get; set; }
        public string From { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
        public DateTime DepartureTime { get; set; }
        public int NumberOfSeats { get; set; }
    }
}
