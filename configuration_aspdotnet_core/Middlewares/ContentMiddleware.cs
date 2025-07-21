//namespace configuration_aspdotnet_core.Middlewares
using Configuation.Services;

namespace Configuation.Middlewares
{
    public class ContentMiddleware
    {
        private RequestDelegate nextDelegate;
        private TotalUsers totalusers;
        public ContentMiddleware(RequestDelegate next,TotalUsers tu)
        {
            nextDelegate = next;
            totalusers = tu;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            if(httpContext.Request.Path.ToString()=="/middleware")
            {
                await httpContext.Response.WriteAsync("This is from the content middleware, Totall Users:"+totalusers.TUsers());
            }
            else
            {
                await nextDelegate.Invoke(httpContext);
            }
        }
    }
}
