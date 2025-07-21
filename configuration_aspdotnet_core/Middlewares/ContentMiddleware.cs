//namespace configuration_aspdotnet_core.Middlewares
namespace Configuation.Middlewares
{
    public class ContentMiddleware
    {
        private RequestDelegate nextDelegate;
        public ContentMiddleware(RequestDelegate next) => nextDelegate = next;
        public async Task Invoke(HttpContext httpContext)
        {
            if(httpContext.Request.Path.ToString()=="/middleware")
            {
                await httpContext.Response.WriteAsync("This is from the content middleware.");
            }
            else
            {
                await nextDelegate.Invoke(httpContext);
            }
        }
    }
}
