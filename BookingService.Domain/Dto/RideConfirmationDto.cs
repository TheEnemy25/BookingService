using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Domain.Dto
{
    public class RideConfirmationDto
    {
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public string RouteId { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public IEnumerable<SeatDto> Seats{ get; set; }
        public string ExtraInfo { get; set; }
    }
}
