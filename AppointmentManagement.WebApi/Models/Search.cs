namespace AppointmentManagement.WebApi.Models
{
    public class Search
    {
        public int? agentId { get; set; }
        public DateTime? from { get; set; }
        public DateTime? to { get; set; }
    }
}
