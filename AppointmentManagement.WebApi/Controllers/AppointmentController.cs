using AppointmentManagement.Application.Exceptions;
using AppointmentManagement.Application.Features.Appointment.Commands.CreateAppointment;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentManagement.WebApi.Controllers
{
    public class AppointmentController : BaseController
    {
        private readonly IMediator _mediator;
        protected readonly ILogger<AppointmentController> _logger;

        public AppointmentController(IMediator mediator, ILogger<AppointmentController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateAppointmentCommand createAppointmentCommand)
        {
            try
            {
                var appointment = await _mediator.Send(createAppointmentCommand);
                return Ok(appointment);
            }
            catch (ValidationException validationException)
            {
                _logger.LogError(validationException.Message, validationException);
                return BadRequest(validationException.ValidationErrors);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex.Message);
            }
        }
    }
}
