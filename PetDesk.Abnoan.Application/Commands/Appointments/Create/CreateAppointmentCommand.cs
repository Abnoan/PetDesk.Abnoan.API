using MediatR;
using PetDesk.Abnoan.Domain.Enums;

namespace PetDesk.Abnoan.Application.Commands.Appointments.Create
{
    public class CreateAppointmentCommand : IRequest<int>
    {
        public string PetName { get; set; }
        public DateTime AppointmentAt { get; set; }
        public AnimalTypeEnum AnimalType { get; set; }
        public string? AnimalDescription { get; set; }
        public AppointmentTypeEnum AppointmentType { get; set; }
        public string? AppointmentDescription { get; set; }
    }
}
