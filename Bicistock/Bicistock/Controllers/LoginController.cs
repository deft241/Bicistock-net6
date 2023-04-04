using Bicistock.Common.Models;
using Bicistock.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bicistock.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Index(User intento)
        {
            Logger.Logger logger = new Logger.Logger();

            UserService conexionUsuario = new UserService();
            User resultadoReal = conexionUsuario.MostrarUsuario(intento.UserName);

            if (resultadoReal.UserName is null)
            {
                logger.Alerta("Se ha intentado iniciar sesión con el Name de UserEntity '" + intento.UserName + "', pero no existe");
                //USUARIO NO EXISTE
                HttpContext.Session.SetInt32("errorLogin", 1);
                return View();
            }
            else
            {
                if (conexionUsuario.LoginValidator(intento.UserName, intento.Password))
                {
                    //ES USUARIO
                    if (resultadoReal.Role == 1)
                    {
                        logger.Info("Ha iniciado sesión como cliente: " + intento.UserName);
                        HttpContext.Session.SetString("usuarioActivo", intento.UserName);
                        HttpContext.Session.SetInt32("Role", resultadoReal.Role);

                        return RedirectToAction("Index", "Home");
                    }
                    else if (resultadoReal.Role == 2)
                    {
                        logger.Info("Ha iniciado sesión como empleado: " + intento.UserName);

                        HttpContext.Session.SetString("usuarioActivo", intento.UserName);
                        HttpContext.Session.SetInt32("Role", resultadoReal.Role);


                        return RedirectToAction("Panel", "Admin");
                    }
                }

                HttpContext.Session.SetInt32("errorLogin", 1);
                return View();


            }

        }

        public IActionResult Empleado()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Empleado(User intento)
        {
            Logger.Logger logger = new Logger.Logger();

            UserService conexionUsuario = new UserService();
            User resultadoReal = conexionUsuario.MostrarUsuario(intento.UserName);

            if (resultadoReal.UserName is null)
            {
                //USUARIO NO EXISTE
                HttpContext.Session.SetInt32("errorLogin", 1);
                return View();
            }
            else
            {
                if (resultadoReal.Role == 2)
                {
                    //ES ADMIN
                    if (resultadoReal.Password == intento.Password)
                    {
                        logger.Info("Ha iniciado sesión como empleado: " + intento.UserName);

                        HttpContext.Session.SetString("usuarioActivo", intento.UserName);

                        return RedirectToAction("Panel", "Admin");
                    }

                }
                else
                {
                    //NO ES ADMIN
                    logger.Alerta("Se ha intentado un inicio de sesión a Name de '" + intento.UserName + "', pero no tiene los Role necesarios");
                    HttpContext.Session.SetInt32("errorLogin", 1);
                    return View();
                }
            }
            return View();
        }

        public IActionResult Registro()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Registro(User UserEntity)
        {
            Logger.Logger logger = new Logger.Logger();

            UserService conexionUsuario = new UserService();
            User existeUsu = conexionUsuario.MostrarUsuario(UserEntity.UserName);

            if (string.IsNullOrEmpty(existeUsu.UserName))
            {
                logger.Info("Se ha creado el usuario: " + UserEntity.UserName);
                conexionUsuario.CrearUsuario(UserEntity.UserName, UserEntity.Password, UserEntity.Dni, UserEntity.Name, UserEntity.Surnames, UserEntity.Age, UserEntity.Phone, "F", 1);

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


