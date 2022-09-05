using AutoMapper;
using MediatR;
using PetDesk.Abnoan.Domain.Entities;
using PetDesk.Abnoan.Domain.Repositories;

namespace PetDesk.Abnoan.Application.Commands.Appointments.Create
{
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, int>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;
        public CreateAppointmentCommandHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {     
            var appointment = _mapper.Map<Appointment>(request);
            await _appointmentRepository.CreateAppointment(appointment);
            return appointment.Id;
        }
    }
}
