using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Domain.Dto
{
    public class RouteSearchParamsDto
    {
        public string From { get; set; }
        public string To { get; set; }
        public DateTime DepartureTime { get; set; }
        public int NumberOfSeats{ get; set; }
    }
}
