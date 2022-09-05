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
            await _appointmentRepository.DeleteAppointmentByIdAsync(request.Id);
            return Unit.Value;
        }
    }
}
