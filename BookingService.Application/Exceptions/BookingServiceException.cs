using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Application.Exceptions
{
    public class BookingServiceException : Exception
    {
        public int StatusCode { get; set; }

        public BookingServiceException(string message, int code)
          : base(message)
        {
            StatusCode = code;
        }

        public BookingServiceException(string message, Exception innerException, int code)
            : base(message, innerException)
        {
            StatusCode = code;
        }

        public BookingServiceException(BookingServiceException ex)
        {

        }
    }
}
