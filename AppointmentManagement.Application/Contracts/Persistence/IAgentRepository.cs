using AppointmentManagement.Domain.Entities;

namespace AppointmentManagement.Application.Contracts.Persistence
{
    public interface IAgentRepository : IAsyncRepository<Agent>
    {
        Task<IReadOnlyList<Agent>> ListWithAgentAvailabilitiesAsync(
            DateTime from, DateTime to, int? agentId = null);
    }
}
