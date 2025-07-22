namespace Configuation.Middlerwares
{
    public class ShortCircuitMiddleware
    {
        private RequestDelegate nextDelegate;
        public ShortCircuitMiddleware(RequestDelegate next) => nextDelegate = next;
        public async Task Invoke(HttpContext httpContext)
        {
            //Code For ShortCircuitMiddleware.
            //if (httpContext.Request.Headers["User-Agent"].Any(v => v.Contains("Firefox")))

            //Code for RequestEdditingMiddleware
            if (httpContext.Items["Firefox"] as bool? == true)  
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
