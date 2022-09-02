using PetDesk.Abnoan.Domain.Enums;

namespace PetDesk.Abnoan.Application.ViewModels
{
    public  class AppointmentViewModel
    {
        public string PetName { get; set; }
        public DateTime AppointmentAt { get; set; }
        public AnimalType AnimalType { get; set; }
        public string? AnimalDescription { get; set; }
        public AppointmentType AppointmentType { get; set; }
        public string? AppointmentDescription { get; set; }

    }
}
