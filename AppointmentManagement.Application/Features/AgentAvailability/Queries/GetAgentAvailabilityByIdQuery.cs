using MediatR;

namespace AppointmentManagement.Application.Features.AgentAvailability.Queries
{
    public class GetAgentAvailabilityByIdQuery : IRequest<AgentAvailabilityVm>
    {
        public int Id { get; set; }
    }
}
