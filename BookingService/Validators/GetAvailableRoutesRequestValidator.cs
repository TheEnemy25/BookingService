using BookingService.API.Ride.Requests;
using FluentValidation;

namespace BookingService.API.Validators
{
    public class GetAvailableRoutesRequestValidator : AbstractValidator<GetAvailableRoutesRequest>
    {
        public GetAvailableRoutesRequestValidator()
        {
            RuleFor(availableRoutes => availableRoutes.From)
                .NotNull().WithMessage("From location is required.")
                .NotEmpty().WithMessage("From location cannot be empty.");

            RuleFor(availableRoutes => availableRoutes.To)
                .NotNull().WithMessage("To location is required.")
                .NotEmpty().WithMessage("To location cannot be empty.");

            RuleFor(availableRoutes => availableRoutes.DepartureDate)
                .NotNull().WithMessage("Departure time is required.")
                .NotEmpty().WithMessage("Departure time cannot be empty.");
        }
    }
}
