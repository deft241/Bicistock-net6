using Microsoft.AspNetCore.Mvc;

namespace Bicistock.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {

            return View();
        }

    }
}
