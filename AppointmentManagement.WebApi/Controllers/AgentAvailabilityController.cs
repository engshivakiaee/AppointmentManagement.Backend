using AppointmentManagement.Application.Features.AgentAvailability.Queries;
using AppointmentManagement.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentManagement.WebApi.Controllers
{
    public class AgentAvailabilityController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextHelper _httpContextHelper;
        private readonly ILogger<AgentAvailabilityController> _logger;

        public AgentAvailabilityController(IMediator mediator,
            IHttpContextHelper httpContextHelper,
            ILogger<AgentAvailabilityController> logger)

        {
            _mediator = mediator;
            _logger = logger;
            _httpContextHelper = httpContextHelper;
        }

        [HttpGet("byid")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var timeZone = _httpContextHelper.EndUserTimeZone;
                if (!string.IsNullOrEmpty(timeZone))
                {
                    DateTimeService.EndUserTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZone);
                }

                var agentAvailabilityByIdQuery = new GetAgentAvailabilityByIdQuery()
                {
                    Id = id,
                };

                var agentAvailabilityVm = await _mediator.Send(agentAvailabilityByIdQuery);

                return Ok(agentAvailabilityVm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex.Message);
            }
        }
    }
}
