using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetDesk.Abnoan.Application.Commands.Appointments.Create;
using PetDesk.Abnoan.Application.Commands.Appointments.Delete;
using PetDesk.Abnoan.Application.Commands.Appointments.Update;
using PetDesk.Abnoan.Application.Queries.GetAllAppointments;
using PetDesk.Abnoan.Application.Queries.GetAppointmentById;
using PetDesk.Abnoan.Application.Util;
using PetDesk.Abnoan.Application.ViewModels;
using PetDesk.Abnoan.Domain.Result;

namespace PetDesk.Abnoan.API.Controllers
{
    [Route("api/appointments")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AppointmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get a paginated list of all appointments booked, and it can be filtered by animal type or appointment type in the field query. 
        /// </summary>
        /// <param name="getAllAppointmentsQuery"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllAppointmentQuery getAllAppointmentsQuery)
        {
            PaginationResult<AppointmentViewModel> appointments;
            try
            {
                appointments = await _mediator.Send(getAllAppointmentsQuery);
            }
            catch (Exception ex)
            {
                return BadRequest($"Message : {ex.Message} - Inner Exceptions : {ex.GetInnerExceptions()}");
            }


            return Ok(appointments);
        }

        /// <summary>
        /// Get an appointment by a existing Id;
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetAppointmentByIdQuery(id);

            var appointment = await _mediator.Send(query);

            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment);
        }

        /// <summary>
        /// Create an appointment for your pet, choose the options that better fit, if not have one choose "other" and put a description.
        /// For Animal Type : 0 = Dog, 1 = Cat, 2 = Bird, 3= Other.
        /// For Appointment Type : 0 = Wellness Visit, 1 = Surgery, 2 = Grooming, 3 = Dental, 4 = Other.
        /// </summary>
        /// <param name="command"></param>    
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateAppointmentCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { Id = id }, command);
        }


        /// <summary>
        /// Update an appointment by Id.
        /// </summary>       
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateAppointmentCommand command)
        {
            try
            {
                await _mediator.Send(command);
            }
            catch (Exception ex)
            {
                return BadRequest($"Message : {ex.Message} - Inner Exceptions : {ex.GetInnerExceptions()}");
            }


            return NoContent();
        }


        /// <summary>
        /// Delete an appointment by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteAppointmentCommand(id);

            try
            {
                await _mediator.Send(command);
            }
            catch (Exception ex)
            {
                return BadRequest($"Message : {ex.Message} - Inner Exceptions : {ex.GetInnerExceptions()}");
            }

            return NoContent();
        }
    }
}
