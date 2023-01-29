using AppointmentManagement.Application.Features.AgentAvailability.Queries;
using AppointmentManagement.Application.Features.Agents.Commands.CreateAgent;
using AppointmentManagement.Application.Features.Agents.Queries;
using AppointmentManagement.Application.Features.Appointment.Commands.CreateAppointment;
using AppointmentManagement.Domain.Entities;
using AutoMapper;

namespace AppointmentManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Agent, AgentVm>().ReverseMap();
            CreateMap<Agent, AgentDto>().ReverseMap();
            CreateMap<Agent, CreateAgentCommand>().ReverseMap();

            CreateMap<AgentAvailability, AgentAvailabilityVm>()
                .ForMember(dest => dest.AgentAvailabilityId, opt => opt.MapFrom(src => src.Id));

            CreateMap<AgentAvailability, AgentAvailabilityDto>().ReverseMap();

            CreateMap<TimeSlot, TimeSlotDto>();

            CreateMap<Appointment, CreateAppointmentCommand>().ReverseMap();
        }
    }
}
