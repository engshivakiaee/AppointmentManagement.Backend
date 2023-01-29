namespace AppointmentManagement.Domain.Entities
{
    public class AgentAvailability
    {
        public int Id { get; set; }
        public Agent Agent { get; set; }
        public int AgentId { get; set; }
        public TimeSlot TimeSlot { get; set; }
        public int TimeSlotId { get; set; }
        public DateTime Date { get; set; }
        public Appointment Appointment { get; set; }
    }
}
