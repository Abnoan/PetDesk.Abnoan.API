using AutoMapper;
using Moq;
using PetDesk.Abnoan.Application.Commands.Appointments.Create;
using PetDesk.Abnoan.Application.Commands.Appointments.Delete;
using PetDesk.Abnoan.Application.Mapper;
using PetDesk.Abnoan.Domain.Entities;
using PetDesk.Abnoan.Domain.Enums;
using PetDesk.Abnoan.Domain.Repositories;

namespace PetDesk.Abnoan.UnitTests.Application.Commands
{
    public class DeleteAppointmentCommandHandlerTests
    {
        readonly IMapper mapper;
        public DeleteAppointmentCommandHandlerTests()
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
        public async Task DeleteAppointment_WithValidInput_ShouldReturnTrue()
        {
            //Arrage
            var appointmentRepository = new Mock<IAppointmentRepository>();

            var createAppointmentCommand = new CreateAppointmentCommand
            {
                PetName = "Brill",
                AnimalType = Domain.Enums.AnimalTypeEnum.Bird,
                AppointmentAt = DateTime.Today,
                AppointmentType = Domain.Enums.AppointmentTypeEnum.Surgery
            };

            var appointmentFake = new Appointment
            {
                PetName = "Brill",
                AnimalType = "Bird",         
                AppointmentAt = DateTime.Today,
                AppointmentType = "Surgery",
                Id = 1
            };


            appointmentRepository.Setup(ar => ar.GetAppointmentByIdAsync(It.IsAny<int>()).Result).Returns(appointmentFake);
            var deleteAppointmentCommand = new DeleteAppointmentCommand(1);

            var createHandler = new CreateAppointmentCommandHandler(appointmentRepository.Object, mapper);
            var deleteHandler = new DeleteAppointmentCommandHandler(appointmentRepository.Object);

            //Act
            await createHandler.Handle(createAppointmentCommand, new CancellationToken());
            await deleteHandler.Handle(deleteAppointmentCommand, new CancellationToken());
            var appointment = await appointmentRepository.Object.GetAppointmentByIdAsync(1);

            //Assert
            appointmentRepository.Verify(ar => ar.CreateAppointment(It.IsAny<Appointment>()), Times.Once());
            appointmentRepository.Verify(ar => ar.GetAppointmentByIdAsync(It.IsAny<int>()), Times.AtLeastOnce());
            Assert.Equal(AppointmentStatusEnum.Cancelled, appointment.Status);
        }
    }
}
