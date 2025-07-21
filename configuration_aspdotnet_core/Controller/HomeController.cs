using Configuation.Services;
using Microsoft.AspNetCore.Mvc;

namespace Configuation.Controllers
{
    public class HomeController : Controller
    {
        private TotalUsers totalUesrs;
        public HomeController(TotalUsers tu)
        {
            totalUesrs = tu;
        }
        public String Index()
        {
            return "Total Users: " + totalUesrs.TUsers();
        }
    }
}
