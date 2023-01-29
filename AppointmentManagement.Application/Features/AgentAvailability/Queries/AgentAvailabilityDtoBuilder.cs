using AppointmentManagement.Application.Services;
using AutoMapper;

namespace AppointmentManagement.Application.Features.AgentAvailability.Queries
{
    public static class AgentAvailabilityDtoBuilder
    {
        public static AgentAvailabilityDto Build(Domain.Entities.AgentAvailability agentAvailability
            , IMapper _mapper
            )
        {
            var agentAvailabilityDto = _mapper.Map<AgentAvailabilityDto>(agentAvailability);

            agentAvailabilityDto.TimeSlotDto = TimeSlotDtoBuilder.Build(agentAvailability.TimeSlot, agentAvailability.Date);

            agentAvailabilityDto.Date = agentAvailability.Date.Date.ToLocalDate(agentAvailability.TimeSlot.From);

            agentAvailabilityDto.IsAvailable = agentAvailability.Appointment?.CustomerName == null;

            return agentAvailabilityDto;
        }
    }
}
