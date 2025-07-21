namespace Configuation.Middlerwares
{
    public class ShortCircuitMiddleware
    {
        private RequestDelegate nextDelegate;
        public ShortCircuitMiddleware(RequestDelegate next) => nextDelegate = next;
        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Headers["User-Agent"].Any(v => v.Contains("Firefox")))
            {
                httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            }
            else
            {
                await nextDelegate.Invoke(httpContext);
            }

        }
    }
}
