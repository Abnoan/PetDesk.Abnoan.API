using PetDesk.Abnoan.Domain.Entities;

namespace PetDesk.Abnoan.Domain.Repositories
{
    public interface IAppointmentRepository
    {
        Task CreateAppointment(Appointment appointment);
        Task UpdateAppointment(Appointment appointment);
        Task<Appointment?> GetAppointmentByIdAsync(int id);
        Task DeleteAppointmentByIdAsync(int id);        

    }
}
