using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Domain.Dto
{
    public class BookRideParamsDto
    {
        public string RouteId { get; set; }
        public string From { get; set;}
        public string To { get; set;}
        public int NumberOfSeats { get; set;}
    }
}
