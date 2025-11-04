namespace Clean.API.Middlewares
{
    public class RequestCounterMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestCounterMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var requestCountCookie = context.Request.Cookies["RequestCount"];
            int count = 1;

            if (requestCountCookie != null && int.TryParse(requestCountCookie, out int existingCount))
            {
                count = existingCount + 1;
            }

            context.Response.Cookies.Append("RequestCount", count.ToString());
             await _next(context);
            await context.Response.WriteAsync($"ביקרת באתר {count} פעמים");

        }
    }
}
