using AppointmentManagement.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace AppointmentManagement.Application.Features.Agents.Queries
{
    public class GetAgentsListQueryHandler : IRequestHandler<GetAgentsListQuery, List<AgentVm>>
    {
        private readonly IAgentRepository _agentRepository;
        private readonly IMapper _mapper;
        public GetAgentsListQueryHandler(IAgentRepository agentRepository, IMapper mapper)
        {
            _agentRepository = agentRepository;
            _mapper = mapper;
        }

        public async Task<List<AgentVm>> Handle(GetAgentsListQuery request,
            CancellationToken cancellationToken)
        {
            var agents = await _agentRepository.ListWithAgentAvailabilitiesAsync(
                request.FromDate, request.ToDate, request.AgentId);

            var agentVmList = agents
                .Select(agent => AgentVmBuilder.Build(agent, _mapper))
                .ToList();

            return agentVmList;
        }
    }
}
