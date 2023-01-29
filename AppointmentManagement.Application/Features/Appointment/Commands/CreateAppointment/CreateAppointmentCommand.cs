using AppointmentManagement.Domain.Entities;
using MediatR;

namespace AppointmentManagement.Application.Features.Appointment.Commands.CreateAppointment
{
    public class CreateAppointmentCommand : IRequest<int>
    {
        public int AgentAvailabilityId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerMessage { get; set; }
    }
}
