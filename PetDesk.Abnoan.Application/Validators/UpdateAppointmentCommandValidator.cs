using FluentValidation;
using PetDesk.Abnoan.Application.Commands.Appointments.Update;

namespace PetDesk.Abnoan.Application.Validators
{
    public class UpdateAppointmentCommandValidator : AbstractValidator<UpdateAppointmentCommand>
    {
        public UpdateAppointmentCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotNull()
                .NotEmpty()
                .WithMessage("You need to provide a Id");
        }
    }
}
