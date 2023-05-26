using BookingService.API.Ride.Requests;
using FluentValidation;

namespace BookingService.API.Validators
{
    public class BookRideRequestValidator : AbstractValidator<BookRideRequest>
    {
        public BookRideRequestValidator()
        {
            RuleFor(bookRide => bookRide.RouteId)
                .NotNull().WithMessage("Route ID is required.");

            RuleFor(bookRide => bookRide.From)
                .NotNull().WithMessage("From location is required.")
                .NotEmpty().WithMessage("From location cannot be empty.");

            RuleFor(bookRide => bookRide.To)
                .NotNull().WithMessage("To location is required.")
                .NotEmpty().WithMessage("To location cannot be empty.");

            RuleFor(bookRide => bookRide.NumberOfSeats)
                .NotNull().WithMessage("Number of seats is required.");
        }
    }
}
