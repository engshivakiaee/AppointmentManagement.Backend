using AppointmentManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppointmentManagement.Persistence
{
    public class AppointmentManagementDbContext : DbContext
    {
        public AppointmentManagementDbContext(DbContextOptions<AppointmentManagementDbContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppointmentManagementDbContext).Assembly);
            SeedData(modelBuilder);
        }

        public DbSet<TimeSlot> TimeSlots { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<AgentAvailability> AgentAvailabilities { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        private void SeedData(ModelBuilder modelBuilder)
        {
            var increment = 1;
            for (int i = 9; i <= 18; i++)
            {
                modelBuilder.Entity<TimeSlot>().HasData(new TimeSlot()
                {
                    Id = increment,
                    From = new TimeSpan(i, 0, 0),
                    To = new TimeSpan(i, 30, 0),
                });

                increment++;

                modelBuilder.Entity<TimeSlot>().HasData(new TimeSlot()
                {
                    Id = increment,
                    From = new TimeSpan(i, 30, 0),
                    To = new TimeSpan(i + 1, 0, 0),
                });

                increment++;
            }

            modelBuilder.Entity<Agent>().HasData(new Agent()
            {
                Id = 1,
                FirstName = "Shiva",
                LastName = "Kiaee",
                PhoneNumber = "07123456789"
            });

            modelBuilder.Entity<Agent>().HasData(new Agent()
            {
                Id = 2,
                FirstName = "Eva",
                LastName = "King",
                PhoneNumber = "07123456710"
            });

            increment = 1;

            for (int i = 1; i <= 10; i++)
            {
                modelBuilder.Entity<AgentAvailability>().HasData(
                  new AgentAvailability()
                  {
                      Id = increment,
                      AgentId = 1,
                      Date = DateTime.Now.ToUniversalTime().Date,
                      TimeSlotId = i,
                  });

                increment++;

                modelBuilder.Entity<AgentAvailability>().HasData(
                 new AgentAvailability()
                 {
                     Id = increment,
                     AgentId = 2,
                     Date = DateTime.Now.ToUniversalTime().Date,
                     TimeSlotId = i,
                 });

                increment++;

                modelBuilder.Entity<AgentAvailability>().HasData(
                  new AgentAvailability()
                  {
                      Id = increment,
                      AgentId = 1,
                      Date = DateTime.Now.AddDays(1).ToUniversalTime().Date,
                      TimeSlotId = i,
                  });

                increment++;

                modelBuilder.Entity<AgentAvailability>().HasData(
                  new AgentAvailability()
                  {
                      Id = increment,
                      AgentId = 2,
                      Date = DateTime.Now.AddDays(1).ToUniversalTime().Date,
                      TimeSlotId = i,
                  });

                increment++;

                modelBuilder.Entity<AgentAvailability>().HasData(
                   new AgentAvailability()
                   {
                       Id = increment,
                       AgentId = 2,
                       Date = DateTime.Now.AddDays(2).ToUniversalTime().Date,
                       TimeSlotId = i,
                   });

                increment++;

                modelBuilder.Entity<AgentAvailability>().HasData(
                   new AgentAvailability()
                   {
                       Id = increment,
                       AgentId = 1,
                       Date = DateTime.Now.AddDays(3).ToUniversalTime().Date,
                       TimeSlotId = i,
                   });

                increment++;

            }
        }
    }
}
