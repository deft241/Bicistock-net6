using Bicistock.Common.Models;
using Bicistock.Controllers.Filters;
using Bicistock.Domain.Services;
using Capa_Soporte.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Bicistock.Controllers
{
    [TypeFilter(typeof(AuthorizationHandler))]
    public class CitaController : Controller
    {
        UserService userData = new UserService();

        public IActionResult Pedir()
        {
            string? user = HttpContext.Session.GetString("activeUser");
            int? verified = HttpContext.Session.GetInt32("Verified");
            if (verified != 1)
            {
                return RedirectToAction("Index", "Home");
            }

            BrandService conexionMarca = new BrandService();
            Brand Brand = new Brand();
            AppointmentManager objModeloCita = new AppointmentManager();

            objModeloCita.BrandList = conexionMarca.MostrarMarcas();
            objModeloCita.Date = DateTime.Now.Date;
            objModeloCita.CurrentUser = user;
            return View(objModeloCita);

        }

        [HttpPost]
        public IActionResult Pedir(AppointmentManager cita)
        {
            string? user = HttpContext.Session.GetString("activeUser");
            int? verified = HttpContext.Session.GetInt32("Verified");


            if (!string.IsNullOrEmpty(user) && verified != 1)
            {
                return RedirectToAction("Index", "Home");
            }

            Logger.Logger logger = new Logger.Logger();
            DateTime actual = new DateTime();
            actual = DateTime.Now;
            BrandService conexionMarca = new BrandService();
            AppointmentService conexionCita = new AppointmentService();
            UserService conexionUsuario = new UserService();
            User respuestaUsuario = new User();

            AppointmentManager objModeloCita = new AppointmentManager();


            cita.Brand.Name = conexionMarca.GetBrandById(cita.Brand.Id).Name;

            respuestaUsuario = conexionUsuario.MostrarUsuario(user);

            if (string.IsNullOrEmpty(respuestaUsuario.UserName))
            {
                logger.Error("Se ha intentado crear una cita con un nombre de usuario no valido, el nombre del intento ha sido: " + cita.CurrentUser);
                HttpContext.Session.SetInt32("errorCita", 1);
                return View(cita);
            }
            else
            {
                conexionCita.NuevaCita(cita.Date, actual, respuestaUsuario.UserName, "Pendiente", cita.Brand.Id, cita.Description);

                int idAppointment = conexionCita.GetCitationId(respuestaUsuario.UserName);

                logger.Info("Se ha creado una cita a Name de " + respuestaUsuario.UserName);

                Mail.SendAppointmentEmail(respuestaUsuario.UserEmail, idAppointment, respuestaUsuario.UserName,cita.Brand.Name,cita.Date);
                return RedirectToAction("Status", new { callBack = true });
            }


        }

        public IActionResult Status(bool callBack = false)
        {
            if (callBack)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }



    }
}
