using PetDesk.Abnoan.Domain.Entities;
using PetDesk.Abnoan.Domain.Repositories;

namespace PetDesk.Abnoan.Infrastructure.Persistence.Respositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly PetDeskDbContext _context;
        public AppointmentRepository(PetDeskDbContext context)
        {
            _context = context;
        }

        public async Task CreateAppointment(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
        }

        public Task DeleteAppointmentByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Appointment?> GetAppointmentByIdAsync(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);

            return appointment ?? null;
        }

        public async Task UpdateAppointment(Appointment appointment)
        {            
            throw new NotImplementedException();
        }
    }
}
