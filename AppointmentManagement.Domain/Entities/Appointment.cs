namespace AppointmentManagement.Domain.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public AgentAvailability AgentAvailability { get; set; }
        public int AgentAvailabilityId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerMessage { get; set; }
    }
}
