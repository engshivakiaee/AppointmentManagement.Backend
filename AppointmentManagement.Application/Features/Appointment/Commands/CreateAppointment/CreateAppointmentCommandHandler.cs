using AppointmentManagement.Application.Contracts.Persistence;
using AppointmentManagement.Application.Exceptions;
using AutoMapper;
using MediatR;

namespace AppointmentManagement.Application.Features.Appointment.Commands.CreateAppointment
{
    internal class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, int>
    {
        private readonly IAsyncRepository<Domain.Entities.Appointment> _appointmentRepository;
        private readonly IMapper _mapper;

        public CreateAppointmentCommandHandler(
            IAsyncRepository<Domain.Entities.Appointment> appointmentRepository
            , IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateAppointmentCommand request
            , CancellationToken cancellationToken)
        {
            var appointment = _mapper.Map<Domain.Entities.Appointment>(request);

            var validator = new CreateAppointmentCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Any())
            {
                throw new ValidationException(validationResult);
            }

            appointment = await _appointmentRepository.AddAsync(appointment);
            return appointment.Id;
        }
    }
}
