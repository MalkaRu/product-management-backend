namespace Clean.API.Middlewares
{
    public class TimeBasedAccessMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public TimeBasedAccessMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var currentHour = DateTime.Now.Hour;
            var blockedFromHour = _configuration.GetValue<int>("AccessControl:BlockedFromHour");
            var blockedToHour = _configuration.GetValue<int>("AccessControl:BlockedToHour");

            if (currentHour >= blockedFromHour && currentHour < blockedToHour)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("הגישה לאתר חסומה בין השעות 02:00-05:00");
                return;
            }

            await _next(context);
        }
    }
}