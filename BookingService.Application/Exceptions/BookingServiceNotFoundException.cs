using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Application.Exceptions
{
    public class BookingServiceNotFoundException : BookingServiceException
    {
        public BookingServiceNotFoundException()
            : base("Route not found", (int)HttpStatusCode.NotFound)
        {
        }
        public BookingServiceNotFoundException(string message)
            : base(message, (int)HttpStatusCode.NotFound)
        {
        }
        public BookingServiceNotFoundException(int routeId)
            : base($"Route with id {routeId} not found", (int)HttpStatusCode.NotFound)
        {
        }

        public BookingServiceNotFoundException(string message, Exception innerException)
            : base(message, innerException, (int)HttpStatusCode.NotFound)
        {

        }
    }
}
