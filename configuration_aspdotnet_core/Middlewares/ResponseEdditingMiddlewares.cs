namespace Configuation.Middlewares
{
    public class ResponseEdditingMiddlewares
    {
        private RequestDelegate nextDelegate;
        public ResponseEdditingMiddlewares(RequestDelegate next)
        {
            nextDelegate = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            await nextDelegate.Invoke(httpContext);
            if(httpContext.Response.StatusCode == 401)
            {
                await httpContext.Response.WriteAsync("Firefox Browser is not authorized");
            }
            else if(httpContext.Response.StatusCode == 404)
            {
                await httpContext.Response.WriteAsync("No Response Generated ");
            }
        }
    }
}
