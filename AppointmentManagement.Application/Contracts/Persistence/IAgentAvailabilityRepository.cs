using AppointmentManagement.Domain.Entities;

namespace AppointmentManagement.Application.Contracts.Persistence
{
    public interface IAgentAvailabilityRepository : IAsyncRepository<AgentAvailability>
    {
    }
}
