using BookingService.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Domain.Entities
{
    public class Route
    {
        public int Id { get; set; }
        public string RouteId { get; set; }
        public string TicketCode { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public ICollection<Seat> Seats { get; set; }
        public string ExtraInfo { get; set; }
    }
}
