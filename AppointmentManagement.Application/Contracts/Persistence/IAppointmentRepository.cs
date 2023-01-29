using AppointmentManagement.Domain.Entities;

namespace AppointmentManagement.Application.Contracts.Persistence
{
    public interface IAppointmentRepository : IAsyncRepository<Appointment>
    {
        Task<bool> IsTimeSlotAvailable();
    }
}
