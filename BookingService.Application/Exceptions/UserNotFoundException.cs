using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Application.Exceptions
{
    public class UserNotFoundException : BookingServiceException
    {
        public UserNotFoundException()
          : base("User not found", (int)HttpStatusCode.NotFound)
        {
        }
        public UserNotFoundException(string message)
            : base(message, (int)HttpStatusCode.NotFound)
        {
        }
        public UserNotFoundException(int userId)
            : base($"User with id {userId} not found", (int)HttpStatusCode.NotFound)
        {
        }

        public UserNotFoundException(string message, Exception innerException)
            : base(message, innerException, (int)HttpStatusCode.NotFound)
        {

        }
    }
}
