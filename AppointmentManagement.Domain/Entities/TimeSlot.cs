namespace AppointmentManagement.Domain.Entities
{
    public class TimeSlot
    {
        public int Id { get; set; }
        public TimeSpan From { get; set; }
        public TimeSpan To { get; set; }
    }
}
