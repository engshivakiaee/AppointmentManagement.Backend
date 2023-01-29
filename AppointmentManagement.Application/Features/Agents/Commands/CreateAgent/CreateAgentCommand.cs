using MediatR;

namespace AppointmentManagement.Application.Features.Agents.Commands.CreateAgent
{
    public class CreateAgentCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
