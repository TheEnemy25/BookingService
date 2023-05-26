using BookingService.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookingService.API.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

        public ApiExceptionFilterAttribute()
        {
            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
        {
            {typeof(BookingServiceException), HandleBookingServiceException},
        };
        }

        public override void OnException(ExceptionContext context)
        {
            HandleException(context);

            base.OnException(context);
        }

        private void HandleException(ExceptionContext context)
        {
            Type type = context.Exception.GetType();
            if (_exceptionHandlers.TryGetValue(type, out Action<ExceptionContext>? value))
            {
                value.Invoke(context);

                return;
            }
        }

        private void HandleBookingServiceException(ExceptionContext context)
        {
            var ex = (BookingServiceException)context.Exception;

            context.Result = new ObjectResult(ex.Message)
            {
                StatusCode = ex.StatusCode
            };

            context.ExceptionHandled = true;
        }
    }
}
