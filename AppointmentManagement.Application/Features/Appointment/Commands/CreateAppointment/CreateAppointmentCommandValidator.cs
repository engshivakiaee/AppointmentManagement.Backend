using FluentValidation;

namespace AppointmentManagement.Application.Features.Appointment.Commands.CreateAppointment
{
    public class CreateAppointmentCommandValidator : AbstractValidator<CreateAppointmentCommand>
    {
        public CreateAppointmentCommandValidator()
        {
            RuleFor(p => p.AgentAvailabilityId).NotNull()
                .WithMessage("Please select agent");

            RuleFor(p => p.CustomerName).NotNull().NotEmpty()
                .WithMessage("Please enter first name");

            RuleFor(p => p.CustomerName).MaximumLength(50)
                .WithMessage("Please enter max 50 charachter for name");

            RuleFor(p => p.CustomerMessage).NotNull().NotEmpty()
                .WithMessage("Please enter first message");

            RuleFor(p => p.CustomerMessage).NotNull().NotEmpty()
                .WithMessage("Please enter message");
        }
    }
}
