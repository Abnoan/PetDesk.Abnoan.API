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


        public void Update(string? petName, DateTime? appointmentAt, string? animalType, string? appointmentType,
                            string? animalDescription = null, string? appointmentDescription = null)
        {

            if (petName is not null) PetName = petName;
            if (appointmentAt is not null) AppointmentAt = (DateTime)appointmentAt;
            if (animalType is not null) AnimalType = animalType;
            if (appointmentType is not null) AppointmentType = appointmentType;
            if (animalDescription is not null) AnimalDescription = animalDescription;
            if (appointmentDescription is not null) AppointmentDescription = appointmentDescription;
        }
    }
}
