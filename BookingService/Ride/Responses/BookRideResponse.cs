namespace BookingService.API.Ride.Responses
{
    public class BookRideResponse
    {
        public string TicketCode { get; set; }
        public int RideId { get; set; }
        public string UserId { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public DateTime DepartureTime { get; set; }
        public int NumberOfSeatsBooked { get; set; }
    }
}
