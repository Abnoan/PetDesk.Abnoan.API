using Microsoft.Extensions.DependencyInjection;
using PetDesk.Abnoan.Application.Commands.Appointment.CreateAppointment;
using MediatR;

namespace PetDesk.Abnoan.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //services
            //    .AddMediatR(typeof(CreateAppointmentCommand));

            return services;
        }
    }
}
