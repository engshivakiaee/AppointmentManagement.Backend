using AppointmentManagement.Application.Features.AgentAvailability.Queries;
using AppointmentManagement.Domain.Entities;
using AutoMapper;

namespace AppointmentManagement.Application.Features.Agents.Queries
{
    public static class AgentVmBuilder
    {
        public static AgentVm Build(Agent agent, IMapper _mapper)
        {
            var agentVm = _mapper.Map<AgentVm>(agent);

            agentVm.AgentAvailabilityDtos =
                agent.AgentAvailabilities
                    .Select(agentAvailability => AgentAvailabilityDtoBuilder.Build(agentAvailability, _mapper))
                    .Where(agentAvailability => agentAvailability.IsAvailable)
                    .ToList();

            return agentVm;
        }
    }
}
