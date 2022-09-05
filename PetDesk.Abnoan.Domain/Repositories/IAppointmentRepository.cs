using PetDesk.Abnoan.Domain.Entities;
using PetDesk.Abnoan.Domain.Result;

namespace PetDesk.Abnoan.Domain.Repositories
{
    public interface IAppointmentRepository
    {
        Task CreateAppointment(Appointment appointment);      
        Task<Appointment> GetAppointmentByIdAsync(int id);
        Task DeleteAppointmentByIdAsync(int id);
        Task SaveChangesAsync();

        Task<PaginationResult<Appointment>> GetAllAsync(string query, int page);
    }
}
