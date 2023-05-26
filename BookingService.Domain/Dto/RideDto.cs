namespace BookingService.Domain.Dto
{
    public class RideDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RouteId { get; set; }
        public string TicketCode { get; set; }
    }
}
