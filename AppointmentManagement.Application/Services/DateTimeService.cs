namespace AppointmentManagement.Application.Services
{
    public static class DateTimeService
    {

        public static TimeZoneInfo EndUserTimeZone = TimeZoneInfo.Local;
        public static DateTime ToLocalDate(this DateTime dateTime, TimeSpan timeSpan)
        {
            var newDateTime = dateTime + timeSpan;

            return TimeZoneInfo.ConvertTimeFromUtc(newDateTime, EndUserTimeZone);
        }

        public static TimeSpan ToLocalTime(this DateTime dateTime, TimeSpan timeSpan)
        {
            var newDateTime = dateTime + timeSpan;

            return TimeZoneInfo.ConvertTimeFromUtc(newDateTime, EndUserTimeZone).TimeOfDay;
        }
    }
}
