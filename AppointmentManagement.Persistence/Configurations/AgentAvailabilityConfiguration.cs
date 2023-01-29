using AppointmentManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentManagement.Persistence.Configurations
{
    public class AgentAvailabilityConfiguration : IEntityTypeConfiguration<AgentAvailability>
    {
        public void Configure(EntityTypeBuilder<AgentAvailability> builder)
        {
            builder.HasOne(p => p.Agent).WithMany(p => p.AgentAvailabilities)
                .HasForeignKey(p => p.AgentId);
            builder.HasOne(p => p.TimeSlot);
        }
    }
}
