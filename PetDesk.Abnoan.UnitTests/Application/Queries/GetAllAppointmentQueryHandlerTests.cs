using Moq;
using PetDesk.Abnoan.Application.Queries.GetAllAppointments;
using PetDesk.Abnoan.Domain.Entities;
using PetDesk.Abnoan.Domain.Repositories;
using PetDesk.Abnoan.Domain.Result;

namespace PetDesk.Abnoan.UnitTests.Application.Queries
{
    public class GetAllAppointmentQueryHandlerTests
    {
        [Fact]
        public async Task GetListAppointments_WithValidInput_ShouldReturnAListAppointments()
        {
            //Arrage
            var appointmentRepository = new Mock<IAppointmentRepository>();
            var appointments = new PaginationResult<Appointment>
            {
                Data = new List<Appointment>
                {
                    new Appointment
                    {
                        PetName = "Fifo",
                        AnimalType = "Dog",
                        AppointmentAt = DateTime.Today,
                        AppointmentType = "Wellness"
                    },
                     new Appointment
                    {
                        PetName = "Lifo",
                        AnimalType = "Cat",
                        AppointmentAt = DateTime.Today,
                        AppointmentType = "Dental"
                    }
                },
                Page = 1,
                PageSize = 2,
                ItemsCount = 0,
                TotalPages = 0
            };

            appointmentRepository.Setup(ar => ar.GetAllAsync(It.IsAny<string>(), It.IsAny<int>()).Result).Returns(appointments);
            var query = new GetAllAppointmentQuery { Query = "", Page = 1 };
            var handler = new GetAllAppointmentQueryHandler(appointmentRepository.Object);

            //Act
            var paginationResult = await handler.Handle(query, new CancellationToken());

            // Assert
            Assert.NotNull(paginationResult);
            Assert.NotEmpty(paginationResult.Data);
            Assert.Equal(appointments.Data.Count, paginationResult.Data.Count);

            appointmentRepository.Verify(pr => pr.GetAllAsync(It.IsAny<string>(), It.IsAny<int>()).Result, Times.Once);
        }

        [Fact]
        public async Task GetListAppointments_WithEmptyInput_ShouldReturnEmptyList()
        {
            //Arrage
            var appointmentRepository = new Mock<IAppointmentRepository>();
            var appointments = new PaginationResult<Appointment> {
                Data = new List<Appointment>(),
                Page = 1,
                PageSize = 2,
                ItemsCount = 0,
                TotalPages = 0
            };

            appointmentRepository.Setup(ar => ar.GetAllAsync(It.IsAny<string>(), It.IsAny<int>()).Result).Returns(appointments);
            var query = new GetAllAppointmentQuery { Query = "Tiger", Page = 1 };
            var handler = new GetAllAppointmentQueryHandler(appointmentRepository.Object);

            //Act
            var paginationResult = await handler.Handle(query, new CancellationToken());

            // Assert        
            Assert.NotNull(paginationResult);
            Assert.Equal(0, paginationResult.ItemsCount);

            appointmentRepository.Verify(pr => pr.GetAllAsync(It.IsAny<string>(), It.IsAny<int>()).Result, Times.Once);
        }
    }
}
