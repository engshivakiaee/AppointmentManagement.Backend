namespace AppointmentManagement.WebApi
{
    public interface IHttpContextHelper
    {
        string? EndUserTimeZone { get; }
    }
}