using MediatR;

namespace AppointmentManagement.Application.Features.Agents.Queries
{
    public class GetAgentsListQuery : IRequest<List<AgentVm>>
    {
        public int? AgentId { get; set; }
        public DateTime FromDate { get; set; } 
        public DateTime ToDate { get; set; } 
    }
}
