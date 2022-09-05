using AutoMapper;
using MediatR;
using PetDesk.Abnoan.Application.ViewModels;
using PetDesk.Abnoan.Domain.Repositories;

namespace PetDesk.Abnoan.Application.Queries.GetAppointmentById
{
    public class GetAppointmentByIdQueryHandler : IRequestHandler<GetAppointmentByIdQuery, AppointmentViewModel>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;
        public GetAppointmentByIdQueryHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }
        public async Task<AppointmentViewModel> Handle(GetAppointmentByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _appointmentRepository.GetAppointmentByIdAsync(request.Id);

            if (entity == null) return null;

            var viewModel = _mapper.Map<AppointmentViewModel>(entity);

            return viewModel;
        }
    }
}
