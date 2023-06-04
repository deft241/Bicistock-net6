using Bicistock.Common.Models;
using Bicistock.Controllers.Filters;
using Bicistock.Domain.Services;
using Capa_Soporte.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Bicistock.Controllers
{
    [TypeFilter(typeof(AuthorizationHandler))]
    public class ProfileController : Controller
    {
        UserService userData = new UserService();
        User userEntity = new User();

        public IActionResult Index()
        {
            string sessionStoredUser = HttpContext.Session.GetString("activeUser");
            HttpContext.Session.SetInt32("updateUser", 2);
            userEntity = userData.MostrarUsuario(sessionStoredUser);

            return View(userEntity);
        }

        [HttpPost]
        public IActionResult Index(User newUser)
        {
            string sessionStoredUser = HttpContext.Session.GetString("activeUser");

            bool result = userData.ModifyUser(newUser, sessionStoredUser);

            if (result)
            {
                HttpContext.Session.SetInt32("updateUser", 1);
                return View(newUser);
            }
            else
            {
                HttpContext.Session.SetInt32("updateUser", 0);
                return View(newUser);
            }

        }
        public IActionResult Activate()
        {
            string sessionStoredUser = HttpContext.Session.GetString("activeUser");
            userEntity = userData.MostrarUsuario(sessionStoredUser);
            if (userEntity.Verified == "T")
            {
                return RedirectToAction("Index");
            }
            else
            {
                var rand = new Random().Next(100000, 999999).ToString();
                HttpContext.Session.SetString("codeActivation", rand);
                Mail.SendVerificationEmail(userEntity.UserEmail, rand);
                return View();
            }

        }

        [HttpPost]
        public IActionResult Activate(string code)
        {
            if (code == HttpContext.Session.GetString("codeActivation"))
            {
                string user = HttpContext.Session.GetString("activeUser");
                userData.ActivateUser(user);
                //Remove code from session
                HttpContext.Session.Remove("codeActivation");
                HttpContext.Session.SetInt32("Verified", 1);
                return RedirectToAction("Success", new { callBack = true });
            }
            else
            {
                return RedirectToAction("Error", new { callBack = true });
            }
        }

        public IActionResult Success(bool callBack = false)
        {
            if (callBack)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Error(bool callBack = false)
        {
            if (callBack)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }



        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}