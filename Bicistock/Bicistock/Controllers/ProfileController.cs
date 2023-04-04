using Bicistock.Common.Models;
using Bicistock.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Bicistock.Controllers
{
    public class ProfileController : Controller
    {
        CN_Usuario userData = new CN_Usuario();
        CS_Usuario userEntity = new CS_Usuario();

        public IActionResult Index()
        {
            string sessionStoredUser = HttpContext.Session.GetString("usuarioActivo");
            userEntity = userData.MostrarUsuario(sessionStoredUser);

            return View(userEntity);
        }

        [HttpPost]
        public string Index(CS_Usuario newUser)
        {

            return "FUNCIONA";
        }
        public IActionResult Activate()
        {
            var rand = new Random().Next(100000, 999999).ToString();
            HttpContext.Session.SetString("codeActivation", rand);
            Capa_Soporte.Helpers.Mail.SendEmail("aaronclase24@gmail.com", rand);
            return View();
        }

        [HttpPost]
        public IActionResult Activate(string code)
        {
            if (code == HttpContext.Session.GetString("codeActivation"))
            {
                string user = HttpContext.Session.GetString("usuarioActivo");
                userData.ActivateUser(user);
                //Remove code from session
                HttpContext.Session.Remove("codeActivation");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
    }
}
