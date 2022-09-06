using MediatR;
using PetDesk.Abnoan.Domain.Repositories;

namespace PetDesk.Abnoan.Application.Commands.Appointments.Delete
{
    public class DeleteAppointmentCommandHandler : IRequestHandler<DeleteAppointmentCommand, Unit>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        public DeleteAppointmentCommandHandler(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }
        public async Task<Unit> Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = await _appointmentRepository.GetAppointmentByIdAsync(request.Id);
            appointment.Cancel();

            await _appointmentRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
