using AppointmentManagement.Application.Features.Agents.Queries;
using AutoMapper;

namespace AppointmentManagement.Application.Features.AgentAvailability.Queries
{
    public static class AgentAvailabilityVmBuilder
    {
        public static AgentAvailabilityVm Build(Domain.Entities.AgentAvailability agentAvailability
            , IMapper _mapper)
        {

            var agentAvailabilityVm = _mapper.Map<AgentAvailabilityVm>(agentAvailability);

            agentAvailabilityVm.AgentDto = _mapper.Map<AgentDto>(agentAvailability.Agent);

            agentAvailabilityVm.TimeSlotDto = TimeSlotDtoBuilder.Build(agentAvailability.TimeSlot, agentAvailability.Date);

            return agentAvailabilityVm;
        }
    }
}
