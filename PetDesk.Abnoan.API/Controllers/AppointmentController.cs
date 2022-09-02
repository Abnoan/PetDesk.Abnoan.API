using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PetDesk.Abnoan.API.Controllers
{
    [Route("api/Appointments")]
    public class AppointmentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AppointmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // api/projects?query=net core
        [HttpGet]      
        public async Task<IActionResult> Get(GetAllAppointmentsQuery getAllAppointmentsQuery)
        {
            var projects = await _mediator.Send(getAllProjectsQuery);

            return Ok(projects);
        }

        // api/projects/2
        [HttpGet("{id}")] 
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetAppointmentByIdQuery(id);

            var project = await _mediator.Send(query);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [HttpPost]      
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }


        // api/projects/2
        [HttpPut("{id}")]      
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }


        // api/projects/3 DELETE
        [HttpDelete("{id}")]   
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
