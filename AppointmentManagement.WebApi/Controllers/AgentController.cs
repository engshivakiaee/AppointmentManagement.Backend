using AppointmentManagement.Application.Features.Agents.Queries;
using AppointmentManagement.Application.Services;
using AppointmentManagement.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentManagement.WebApi.Controllers
{
    public class AgentController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextHelper _httpContextHelper;
        private readonly ILogger<AgentController> _logger;

        public AgentController(IMediator mediator,
            IHttpContextHelper httpContextHelper,
            ILogger<AgentController> logger)
        {
            _mediator = mediator;
            _httpContextHelper = httpContextHelper;
            _logger = logger;
        }

        [HttpPost("agentlist-with-availabilities")]
        public async Task<IActionResult> GetAgentsListWithAvailabilities(Search search)
        {
            try
            {
                var timeZone = _httpContextHelper.EndUserTimeZone;
                if (!string.IsNullOrEmpty(timeZone))
                {
                    DateTimeService.EndUserTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZone);
                }

                var getAgentsListQuery = new GetAgentsListQuery()
                {
                    AgentId = search?.agentId,
                    FromDate = search?.from ?? DateTime.Parse("2023-01-01"),
                    ToDate = search?.to ?? DateTime.Parse("2030-01-01"),
                };

                var agentVms = await _mediator.Send(getAgentsListQuery);

                return Ok(agentVms);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex.Message);
            }
        }
    }
}
