using AppointmentManagement.Application.Services;
using AppointmentManagement.Domain.Entities;

namespace AppointmentManagement.Application.Features.AgentAvailability.Queries
{
    public static class TimeSlotDtoBuilder
    {
        public static TimeSlotDto Build(TimeSlot timeSlot, DateTime dateTime)
        {
            var timeSlotDto = new TimeSlotDto();
            timeSlotDto.From = dateTime.ToLocalTime(timeSlot.From);
            timeSlotDto.To = dateTime.ToLocalTime(timeSlot.To);
            return timeSlotDto;
        }
    }
}
