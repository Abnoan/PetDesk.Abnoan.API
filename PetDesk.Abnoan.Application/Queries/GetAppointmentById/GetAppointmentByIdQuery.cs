using MediatR;
using PetDesk.Abnoan.Application.ViewModels;

namespace PetDesk.Abnoan.Application.Queries.GetAppointmentById
{
    public class GetAppointmentByIdQuery : IRequest<AppointmentViewModel>
    {
        public GetAppointmentByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
