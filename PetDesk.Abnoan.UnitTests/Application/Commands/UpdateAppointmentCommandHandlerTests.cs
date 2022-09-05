using AutoMapper;
using Moq;
using PetDesk.Abnoan.Application.Commands.Appointments.Create;
using PetDesk.Abnoan.Application.Commands.Appointments.Update;
using PetDesk.Abnoan.Application.Mapper;
using PetDesk.Abnoan.Domain.Entities;
using PetDesk.Abnoan.Domain.Repositories;

namespace PetDesk.Abnoan.UnitTests.Application.Commands
{
    public class UpdateAppointmentCommandHandlerTests
    {
        readonly IMapper mapper;
        public UpdateAppointmentCommandHandlerTests()
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
        public async Task UpdateAppointment_WithValidInput_ShouldReturnValueUpdated()
        {
            //Arrage
            var appointmentRepository = new Mock<IAppointmentRepository>();

            var appointmentFake = new Appointment
            {
                PetName = "Buba",
                AnimalType = "Other",
                AnimalDescription = "Pokemon",
                AppointmentAt = DateTime.Now,
                AppointmentType = "Dental",
                Id = 1
            };

            var updateAppointmentCommand = new UpdateAppointmentCommand()
            {
                Id = 1,
                PetName = "Buba, The Second"
            };

            appointmentRepository.Setup(ar => ar.GetAppointmentByIdAsync(It.IsAny<int>()).Result).Returns(appointmentFake);            
            var updateHandler = new UpdateAppointmentCommandHandler(appointmentRepository.Object);

            //Act
          
            await updateHandler.Handle(updateAppointmentCommand, new CancellationToken());
            var appointmentUpdated = await appointmentRepository.Object.GetAppointmentByIdAsync(updateAppointmentCommand.Id);

            //Assert
            appointmentRepository.Verify(ar => ar.GetAppointmentByIdAsync(It.IsAny<int>()), Times.AtLeastOnce());
            Assert.Equal(updateAppointmentCommand.PetName, appointmentUpdated.PetName);
        }

        [Fact]
        public async Task UpdateAppointment_WithInvalidInput_ShouldReturnTrue()
        {
            //Arrage
            var appointmentRepository = new Mock<IAppointmentRepository>();

            var appointmentFake = new Appointment
            {
                PetName = "Buba",
                AnimalType = "Other",
                AnimalDescription = "Pokemon",
                AppointmentAt = DateTime.Now,
                AppointmentType = "Dental",
                Id = 1
            };

            var updateAppointmentCommand = new UpdateAppointmentCommand()
            {
                Id = 2,
                PetName = "Buba, The Second"
            };

            appointmentRepository.Setup(ar => ar.GetAppointmentByIdAsync(It.IsAny<int>()).Result).Returns(appointmentFake);
            var updateHandler = new UpdateAppointmentCommandHandler(appointmentRepository.Object);

            //Act

            await updateHandler.Handle(updateAppointmentCommand, new CancellationToken());
            var appointmentUpdated = await appointmentRepository.Object.GetAppointmentByIdAsync(updateAppointmentCommand.Id);

            //Assert
            appointmentRepository.Verify(ar => ar.GetAppointmentByIdAsync(It.IsAny<int>()), Times.AtLeastOnce());
            Assert.NotEqual(updateAppointmentCommand.Id, appointmentUpdated.Id);          

        }
    }
}
