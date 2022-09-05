using MediatR;
using PetDesk.Abnoan.Application.ViewModels;
using PetDesk.Abnoan.Domain.Result;

namespace PetDesk.Abnoan.Application.Queries.GetAllAppointments
{
    public class GetAllAppointmentQuery : IRequest<PaginationResult<AppointmentViewModel>>
    {
        public string? Query { get; set; }
        public int Page { get; set; } = 1;
    }
}
