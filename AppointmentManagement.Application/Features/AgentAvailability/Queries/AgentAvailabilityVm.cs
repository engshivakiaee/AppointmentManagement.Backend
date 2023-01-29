using AppointmentManagement.Application.Features.Agents.Queries;

namespace AppointmentManagement.Application.Features.AgentAvailability.Queries
{
    public class AgentAvailabilityVm
    {
        public int AgentAvailabilityId { get; set; }
        public AgentDto AgentDto { get; set; }
        public DateTime Date { get; set; }
        public TimeSlotDto TimeSlotDto { get; set; }
        public bool IsAvailable { get; set; }
    }
}