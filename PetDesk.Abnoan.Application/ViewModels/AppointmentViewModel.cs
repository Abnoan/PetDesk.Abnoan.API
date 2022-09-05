namespace PetDesk.Abnoan.Application.ViewModels
{
    public  class AppointmentViewModel
    {
        public AppointmentViewModel(int id, string petName, DateTime appointmentAt, string animalType, 
                                    string? animalDescription, string appointmentType, string? appointmentDescription)
        {
            Id = id;
            PetName = petName;
            AppointmentAt = appointmentAt;
            AnimalType = animalType;
            AnimalDescription = animalDescription;
            AppointmentType = appointmentType;
            AppointmentDescription = appointmentDescription;
        }

        public int Id { get; set; }
        public string PetName { get; set; }
        public DateTime AppointmentAt { get; set; }
        public string AnimalType { get; set; }
        public string? AnimalDescription { get; set; }
        public string AppointmentType { get; set; }
        public string? AppointmentDescription { get; set; }

    }
}
