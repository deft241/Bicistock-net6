using Bicistock.Common.Models;
using Bicistock.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bicistock.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.SetInt32("errorLogin", 0);
            return View();

        }

        [HttpPost]
        public IActionResult Index(User attempt)
        {
            Logger.Logger logger = new Logger.Logger();

            UserService conexionUsuario = new UserService();

            if (string.IsNullOrEmpty(attempt.UserName) || string.IsNullOrEmpty(attempt.Password))
            {
                //No data provided
                HttpContext.Session.SetInt32("errorLogin", 1);
                return View();
            }

            User resultadoReal = conexionUsuario.MostrarUsuario(attempt.UserName);

            if (resultadoReal.UserName is null)
            {
                //User dont exist
                logger.Alerta("Se ha intentado iniciar sesión con el Name de UserEntity '" + attempt.UserName + "', pero no existe");
                HttpContext.Session.SetInt32("errorLogin", 1);
                return View();
            }
            else
            {
                if (conexionUsuario.LoginValidator(attempt.UserName, attempt.Password))
                {
                    if (resultadoReal.Role == 1)
                    {
                        //Authorized as user
                        logger.Info("Ha iniciado sesión como cliente: " + attempt.UserName);
                        HttpContext.Session.SetString("activeUser", attempt.UserName);
                        HttpContext.Session.SetInt32("Role", resultadoReal.Role);
                        if (resultadoReal.Verified == "T")
                        {
                            HttpContext.Session.SetInt32("Verified", 1);
                        }
                        else
                        {
                            HttpContext.Session.SetInt32("Verified", 0);
                        }


                        return RedirectToAction("Index", "Home");
                    }
                    else if (resultadoReal.Role == 2)
                    {
                        //Authorized as admin
                        logger.Info("Ha iniciado sesión como empleado: " + attempt.UserName);

                        HttpContext.Session.SetString("activeUser", attempt.UserName);
                        HttpContext.Session.SetInt32("Role", resultadoReal.Role);


                        return RedirectToAction("Panel", "Admin");
                    }
                }

                HttpContext.Session.SetInt32("errorLogin", 1);
                return View();
            }
        }

        public IActionResult Register()
        {
            HttpContext.Session.SetInt32("errorLogin", 0);
            HttpContext.Session.SetInt32("existeUsuario", 0);
            return View();
        }

        [HttpPost]
        public IActionResult Register(User UserEntity)
        {
            Logger.Logger logger = new Logger.Logger();
            if (string.IsNullOrEmpty(UserEntity.UserName) || string.IsNullOrEmpty(UserEntity.UserEmail) || string.IsNullOrEmpty(UserEntity.Password) || string.IsNullOrEmpty(UserEntity.Name))
            {
                //Not enough data provided
                HttpContext.Session.SetInt32("errorLogin", 1);
                return View();
            }

            UserService conexionUsuario = new UserService();
            User existeUsu = conexionUsuario.MostrarUsuario(UserEntity.UserName);

            if (string.IsNullOrEmpty(existeUsu.UserName))
            {
                logger.Info("Se ha creado el usuario: " + UserEntity.UserName);
                conexionUsuario.CrearUsuario(UserEntity.UserName, UserEntity.Password, UserEntity.Dni, UserEntity.Name, UserEntity.Surnames, UserEntity.Age, UserEntity.Phone, "F", 1, UserEntity.UserEmail);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                logger.Alerta("Se ha intentado crear un UserEntity con un Name ya existente. INTENTO: " + UserEntity.UserName);
                HttpContext.Session.SetInt32("existeUsuario", 1);

                return View(UserEntity);
            }
        }
    }
}


