using AppointmentManagement.Application.Features.AgentAvailability.Queries;

namespace AppointmentManagement.Application.Features.Agents.Queries
{
    public class AgentVm
    {
        public int Id { get; set; }//AgentId
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public IReadOnlyList<AgentAvailabilityDto> AgentAvailabilityDtos { get; set; }
    }
}
