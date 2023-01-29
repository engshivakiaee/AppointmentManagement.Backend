using AppointmentManagement.Application.Contracts.Persistence;
using AppointmentManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppointmentManagement.Persistence.Repositories
{
    public class AgentAvailabilityRepository : BaseRepository<AgentAvailability>, IAgentAvailabilityRepository
    {
        public AgentAvailabilityRepository(AppointmentManagementDbContext dbContext)
            : base(dbContext)
        {
        }

        public async override Task<AgentAvailability> GetByIdAsync(int id)
        {
            var agentAvailability = _dbContext.Set<AgentAvailability>()
                .Where(s => s.Id == id)
                .Include(s => s.Agent)
                .Include(s => s.TimeSlot)
                .SingleOrDefaultAsync();

            return await agentAvailability;
        }
    }
}
