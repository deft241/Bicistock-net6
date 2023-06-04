using Microsoft.AspNetCore.Mvc;

namespace Bicistock.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
