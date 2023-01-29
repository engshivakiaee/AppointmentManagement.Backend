namespace AppointmentManagement.WebApi
{
    public class HttpContextHelper : IHttpContextHelper
    {

        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpContextHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string? EndUserTimeZone
        {
            get
            {
                string? timeZone = null;

                if (_httpContextAccessor.HttpContext != null)
                {
                    timeZone = _httpContextAccessor.HttpContext.Request.Headers["timezone"];
                }

                return timeZone;
            }
        }
    }
}
