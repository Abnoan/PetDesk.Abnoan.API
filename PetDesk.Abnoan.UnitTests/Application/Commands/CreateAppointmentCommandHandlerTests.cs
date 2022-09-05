using AutoMapper;
using Moq;
using PetDesk.Abnoan.Application.Commands.Appointments.Create;
using PetDesk.Abnoan.Application.Mapper;
using PetDesk.Abnoan.Domain.Entities;
using PetDesk.Abnoan.Domain.Repositories;

namespace PetDesk.Abnoan.UnitTests.Application.Commands
{
    public class CreateAppointmentCommandHandlerTests
    {
        readonly IMapper mapper;
        public CreateAppointmentCommandHandlerTests()
        {
            mapper = SetupMapper();
        }

        private static IMapper SetupMapper()
        {
            var profile = new AppointmentMapper();
            var mapConfig = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            return new Mapper(mapConfig);
        }

        [Fact]
        public async Task CreateAppointment_WithValidInput_ShouldReturnCreated()
        {
            //Arrage
            var appointmentRepository = new Mock<IAppointmentRepository>();       
            
            var appointmentCommand = new CreateAppointmentCommand
            {
                PetName = "Brill",
                AnimalType = Domain.Enums.AnimalType.Bird,
                AppointmentAt = DateTime.Today,
                AppointmentType = Domain.Enums.AppointmentType.Surgery
            };
          
            var handler = new CreateAppointmentCommandHandler(appointmentRepository.Object, mapper);            

            //Act
            await handler.Handle(appointmentCommand, new CancellationToken());

            //Assert
            appointmentRepository.Verify(ar => ar.CreateAppointment(It.IsAny<Appointment>()), Times.Once());
                    
        }

        [Fact]
        public async Task CreateAppointment_WithInvalidInput_ShouldReturnFalse()
        {
            //Arrage
            var appointmentRepository = new Mock<IAppointmentRepository>();
            var appointmentCommand = new CreateAppointmentCommand
            {
                PetName = String.Empty,
                AnimalType = Domain.Enums.AnimalType.Bird,
                AppointmentAt = DateTime.Today,
                AppointmentType = Domain.Enums.AppointmentType.Surgery
            };

            var handler = new CreateAppointmentCommandHandler(appointmentRepository.Object, mapper);

            //Act
            await handler.Handle(appointmentCommand, new CancellationToken());

            //Assert
            appointmentRepository.Verify(ar => ar.CreateAppointment(It.IsAny<Appointment>()), Times.Once());         

        }
    }
}
