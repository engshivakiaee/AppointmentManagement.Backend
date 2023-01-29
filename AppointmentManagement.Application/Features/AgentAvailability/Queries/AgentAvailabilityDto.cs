namespace AppointmentManagement.Application.Features.AgentAvailability.Queries
{
    public class AgentAvailabilityDto
    {
        public AgentAvailabilityDto()
        {
            TimeSlotDto = new TimeSlotDto();
        }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSlotDto TimeSlotDto { get; set; }
        public bool IsAvailable { get; set; }
    }
}
