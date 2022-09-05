using MediatR;

namespace PetDesk.Abnoan.Application.Commands.Appointments.Delete
{
    public class DeleteAppointmentCommand : IRequest<Unit>
    {
        public DeleteAppointmentCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
