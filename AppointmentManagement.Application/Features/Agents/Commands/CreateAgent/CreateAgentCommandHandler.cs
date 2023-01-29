using AppointmentManagement.Application.Contracts.Persistence;
using AppointmentManagement.Application.Exceptions;
using AppointmentManagement.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AppointmentManagement.Application.Features.Agents.Commands.CreateAgent
{
    public class CreateAgentCommandHandler : IRequestHandler<CreateAgentCommand, int>
    {
        private readonly IAsyncRepository<Agent> _agentRepository;
        private readonly IMapper _mapper;

        public CreateAgentCommandHandler(IAsyncRepository<Agent> agentRepository, IMapper mapper)
        {
            _agentRepository = agentRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateAgentCommand request, CancellationToken cancellationToken)
        {
            var agent = _mapper.Map<Agent>(request);

            var validator = new CreateAgentCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Any())
            {
                throw new ValidationException(validationResult);
            }

            agent = await _agentRepository.AddAsync(@agent);
            return agent.Id;
        }
    }
}
