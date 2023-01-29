using AppointmentManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentManagement.Persistence.Configurations
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasOne(p => p.AgentAvailability).WithOne(p => p.Appointment)
                .HasForeignKey<Appointment>(p=>p.AgentAvailabilityId);
            builder.Property(p => p.CustomerName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.CustomerMessage).HasMaxLength(100);
        }
    }
}
