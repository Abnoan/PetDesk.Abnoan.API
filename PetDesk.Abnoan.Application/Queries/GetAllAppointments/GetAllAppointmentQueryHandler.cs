using MediatR;
using PetDesk.Abnoan.Application.ViewModels;
using PetDesk.Abnoan.Domain.Repositories;
using PetDesk.Abnoan.Domain.Result;

namespace PetDesk.Abnoan.Application.Queries.GetAllAppointments
{
    public class GetAllAppointmentQueryHandler : IRequestHandler<GetAllAppointmentQuery, PaginationResult<AppointmentViewModel>>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        public GetAllAppointmentQueryHandler(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }
        public async Task<PaginationResult<AppointmentViewModel>> Handle(GetAllAppointmentQuery request, CancellationToken cancellationToken)
        {
            var appointmentPaginationResult = await _appointmentRepository.GetAllAsync(request.Query, request.Page);

            var appointmentViewModel = appointmentPaginationResult
              .Data
              .Select(p => new AppointmentViewModel(p.Id, p.PetName, p.AppointmentAt, p.AnimalType, p.AnimalDescription,
                                                    p.AppointmentType, p.AppointmentDescription))
              .ToList();

            var paginationResult = new PaginationResult<AppointmentViewModel>(
               appointmentPaginationResult.Page,
               appointmentPaginationResult.TotalPages,
               appointmentPaginationResult.PageSize,
               appointmentPaginationResult.ItemsCount,
               appointmentViewModel
            );

            return paginationResult;
        }
    }
}
