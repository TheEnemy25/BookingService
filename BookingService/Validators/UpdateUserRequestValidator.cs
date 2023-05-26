using BookingService.API.User.Requests;
using FluentValidation;

namespace BookingService.API.Validators
{
    public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserRequestValidator()
        {
            RuleFor(user => user.UserId)
           .NotNull()
           .WithMessage("User ID is required.");

            RuleFor(user => user.FirstName)
                .NotNull()
                .NotEmpty()
                .WithMessage("First name is required.");

            RuleFor(user => user.LastName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Last name is required.");

            RuleFor(user => user.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Valid email address is required.");

            RuleFor(user => user.Birthday)
                .NotNull()
                .Must(BeValidBirthDate)
                .WithMessage("Valid birth date is required.");

            RuleFor(user => user.Password)
                .NotNull()
                .NotEmpty()
                .MinimumLength(6)
                .WithMessage("Password must be at least 6 characters long.");
        }
        private bool BeValidBirthDate(DateTime birthDate)
        {
            var age = DateTime.Today.Year - birthDate.Year;
            if (birthDate.Date > DateTime.Today.AddYears(-age))
            {
                age--;
            }
            return age >= 16;
        }
    }
    
}
