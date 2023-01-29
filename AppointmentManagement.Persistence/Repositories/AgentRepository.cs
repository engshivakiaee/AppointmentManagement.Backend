using AppointmentManagement.Application.Contracts.Persistence;
using AppointmentManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppointmentManagement.Persistence.Repositories
{
    public class AgentRepository : BaseRepository<Agent>, IAgentRepository
    {
        public AgentRepository(AppointmentManagementDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IReadOnlyList<Agent>> ListWithAgentAvailabilitiesAsync(
            DateTime from, DateTime to, int? agentId = null)
        {
            var agentQuery = _dbContext.Set<Agent>().AsQueryable();

            if (agentId != null)
            {
                agentQuery = agentQuery.Where(a => a.Id == agentId);
            }

            agentQuery = agentQuery
                 .Include(a => a.AgentAvailabilities
                    .Where(aa => aa.Date.Date >= from.Date && aa.Date.Date <= to.Date))
                 .ThenInclude(s => s.TimeSlot)
                 .Include(s => s.AgentAvailabilities)
                 .ThenInclude(s => s.Appointment)
                 .AsQueryable();

            return await agentQuery.ToListAsync();
        }
    }
}
