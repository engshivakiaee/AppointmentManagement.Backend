using FluentValidation;

namespace AppointmentManagement.Application.Features.Agents.Commands.CreateAgent
{
    public class CreateAgentCommandValidator : AbstractValidator<CreateAgentCommand>
    {
        public CreateAgentCommandValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty().NotNull()
                .WithMessage("Please enter first name");

            RuleFor(p => p.FirstName).MaximumLength(50)
                .WithMessage("Please enter max 50 charachter for first name");

            RuleFor(p => p.LastName).NotEmpty().NotNull()
                .WithMessage("Please enter last name");

            RuleFor(p => p.LastName).MaximumLength(50)
                .WithMessage("Please enter max 50 charachter for last name");

            RuleFor(p => p.PhoneNumber).NotNull().NotEmpty()
                .WithMessage("Please enter phone number");

            RuleFor(p => p.PhoneNumber).MaximumLength(50)
                .WithMessage("Please enter max 50 charachter for PhoneNumber");
        }
    }
}
