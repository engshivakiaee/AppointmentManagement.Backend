namespace AppointmentManagement.Application.Features.AgentAvailability.Queries
{
    public class TimeSlotDto
    {
        public int Id { get; set; }
        public TimeSpan From { get; set; }
        public TimeSpan To { get; set; }
    }
}
