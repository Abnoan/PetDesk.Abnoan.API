using FluentValidation;
using PetDesk.Abnoan.Application.Commands.Appointments.Create;

namespace PetDesk.Abnoan.Application.Validators
{
    public class CreateAppointmentCommandValidator : AbstractValidator<CreateAppointmentCommand>
    {
        public CreateAppointmentCommandValidator()
        {
            RuleFor(p => p.PetName)
                .NotNull()
                .NotEmpty()
                .WithMessage("PetName can't be null or empty");

            RuleFor(p => p.AnimalType)
              .IsInEnum()
              .NotNull()
              .WithMessage("You need to provide a valid Animal Type.");

            RuleFor(p => p.AppointmentType)
             .IsInEnum()
             .NotNull()
             .WithMessage("You need to provide a valid Appointment Type.");

            RuleFor(p => p.AppointmentAt)
            .NotNull()
            .NotEmpty()
            .WithMessage("You need to provide a datetime for the appointment.");

        }
    }
}
