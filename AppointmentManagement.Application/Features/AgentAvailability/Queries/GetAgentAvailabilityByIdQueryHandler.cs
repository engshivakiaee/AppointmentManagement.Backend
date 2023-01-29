using AppointmentManagement.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace AppointmentManagement.Application.Features.AgentAvailability.Queries
{
    public class GetAgentAvailabilityByIdQueryHandler : IRequestHandler<GetAgentAvailabilityByIdQuery
        , AgentAvailabilityVm>
    {
        private readonly IAgentAvailabilityRepository _agentAvailabilityRepository;
        private readonly IMapper _mapper;

        public GetAgentAvailabilityByIdQueryHandler(
            IAgentAvailabilityRepository agentAvailabilityRepository,
            IMapper mapper)
        {
            _agentAvailabilityRepository = agentAvailabilityRepository;
            _mapper = mapper;
        }
        public async Task<AgentAvailabilityVm> Handle(GetAgentAvailabilityByIdQuery request
            , CancellationToken cancellationToken)
        {
            var agentAvailability = await _agentAvailabilityRepository.GetByIdAsync(request.Id);

            return AgentAvailabilityVmBuilder.Build(agentAvailability, _mapper);
        }
    }
}
