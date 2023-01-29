namespace AppointmentManagement.Domain.Entities
{
    public class Agent
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<AgentAvailability> AgentAvailabilities { get; set; }
    }
}
