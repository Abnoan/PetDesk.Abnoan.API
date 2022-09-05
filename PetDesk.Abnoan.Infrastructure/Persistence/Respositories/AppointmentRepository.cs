using Microsoft.EntityFrameworkCore;
using PetDesk.Abnoan.Domain.Entities;
using PetDesk.Abnoan.Domain.Repositories;
using PetDesk.Abnoan.Domain.Result;

namespace PetDesk.Abnoan.Infrastructure.Persistence.Respositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly PetDeskDbContext _context;
        private const int PAGE_SIZE = 2;
        public AppointmentRepository(PetDeskDbContext context)
        {
            _context = context;
        }

        public async Task CreateAppointment(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAppointmentByIdAsync(int id)
        {
            var appointment = await GetAppointmentByIdAsync(id);
            _context.Remove(appointment);
            _context.SaveChanges();
        }

        public async Task<Appointment> GetAppointmentByIdAsync(int id)
        {
            var appointment = await _context.Appointments.SingleOrDefaultAsync(app => app.Id == id);
            if (appointment is null)
            {
                throw new NullReferenceException();
            }

            return appointment;
        }

        public async Task<PaginationResult<Appointment>> GetAllAsync(string? query, int page)
        {
            // Filtro
            IQueryable<Appointment> appointments = _context.Appointments;

            if (!string.IsNullOrWhiteSpace(query))
            {
                appointments = appointments
                    .Where(p =>
                        p.AnimalType.Contains(query) ||
                        p.AppointmentType.Contains(query));
            }

            return await appointments.GetPaged<Appointment>(page, PAGE_SIZE);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
