using AutoMapper;
using PetDesk.Abnoan.Application.Commands.Appointments.Create;
using PetDesk.Abnoan.Application.ViewModels;
using PetDesk.Abnoan.Domain.Entities;

namespace PetDesk.Abnoan.Application.Mapper
{
    public class AppointmentMapper : Profile
    {
        public AppointmentMapper()
        {
            CreateMap<Appointment, AppointmentViewModel>()              
                .ReverseMap();

            CreateMap<Appointment, CreateAppointmentCommand>()
                .ReverseMap();
        }
    }
}
