using AutoMapper;
using Moq;
using PetDesk.Abnoan.Application.Mapper;
using PetDesk.Abnoan.Application.Queries.GetAppointmentById;
using PetDesk.Abnoan.Domain.Entities;
using PetDesk.Abnoan.Domain.Repositories;

namespace PetDesk.Abnoan.UnitTests.Application.Queries
{
    public class GetAppointmentByIdQueryHandlerTests
    {
        readonly IMapper mapper;
        public GetAppointmentByIdQueryHandlerTests()
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
        public async Task GetAppointmentById_WithValidId_ShoudlReturnAppointment()
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

            var query = new GetAppointmentByIdQuery(1);
            appointmentRepository.Setup(ar => ar.GetAppointmentByIdAsync(query.Id)).ReturnsAsync(appointmentFake);
            var handler = new GetAppointmentByIdQueryHandler(appointmentRepository.Object, mapper);

            //Act
            var result = await handler.Handle(query, new CancellationToken());

            //Assert
            Assert.NotNull(result);
            Assert.Equal(appointmentFake.PetName, result.PetName);

            appointmentRepository.Verify(ar => ar.GetAppointmentByIdAsync(query.Id).Result, Times.Once);
        }

        [Fact]
        public async Task GetAppointmentById_WithInvalidId_ShoudlReturn404()
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

            var query = new GetAppointmentByIdQuery(1);
            appointmentRepository.Setup(ar => ar.GetAppointmentByIdAsync(2)).ReturnsAsync(appointmentFake);
            var handler = new GetAppointmentByIdQueryHandler(appointmentRepository.Object, mapper);

            //Act
            var result = await handler.Handle(query, new CancellationToken());

            //Assert
            Assert.Null(result);
        }
    }
}
