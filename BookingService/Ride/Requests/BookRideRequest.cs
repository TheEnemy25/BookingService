namespace BookingService.API.Ride.Requests
{
    public class BookRideRequest
    {
        public int UserId { get; set; }
        public string RouteId { get; set; }
        public string TicketCode { get; set; }
    }
}
