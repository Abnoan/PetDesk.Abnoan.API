using MediatR;
using PetDesk.Abnoan.Application.Util;
using PetDesk.Abnoan.Domain.Repositories;

namespace PetDesk.Abnoan.Application.Commands.Appointments.Update
{
    public class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommand, Unit>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        public UpdateAppointmentCommandHandler(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }
        public async Task<Unit> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = await _appointmentRepository.GetAppointmentByIdAsync(request.Id);
            appointment.Update(request.PetName, request.AppointmentAt, request.AnimalType.ToDescriptionString(),
                               request.AppointmentType.ToDescriptionString(), request.AnimalDescription, request.AppointmentDescription);

            await _appointmentRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
