using DevFreela.Core.Entities;

namespace PetDesk.Abnoan.Domain.Entities
{
    public class Appointment : BaseEntity
    {
        public string PetName { get; set; }
        public DateTime AppointmentAt { get; set; }
        public string AnimalType { get; set; }
        public string? AnimalDescription { get; set; }
        public string AppointmentType { get; set; }
        public string? AppointmentDescription { get; set; }
    }
}
