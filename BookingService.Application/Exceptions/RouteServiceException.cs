using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Application.Exceptions
{
    public class RouteServiceException : BookingServiceException
    {
        public RouteServiceException()
           : base("Error occured when calling RouteService", (int)HttpStatusCode.InternalServerError)
        {
        }
        public RouteServiceException(string message)
            : base(message, (int)HttpStatusCode.InternalServerError)
        {
        }

        public RouteServiceException(string message, HttpStatusCode httpStatusCode)
            : base(message, (int)httpStatusCode)
        {
        }

        public RouteServiceException(string message, Exception innerException)
            : base(message, innerException, (int)HttpStatusCode.InternalServerError)
        {

        }
    }
}
