using Bicistock.Common.Models;
using Bicistock.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bicistock.Controllers
{

    public class CitaController : Controller
    {
        UserService userData = new UserService();

        public IActionResult Pedir()
        {
            string user = HttpContext.Session.GetString("usuarioActivo");

            //if (!userData.IsVerified(user)) 
            //{
            //    return RedirectToAction("Index","Home");
            //}
            Bicistock.Domain.Services.
            BrandService conexionMarca = new BrandService();
            Brand Brand = new Brand();
            AppointmentManager objModeloCita = new AppointmentManager();

            objModeloCita.BrandList = conexionMarca.MostrarMarcas();
            return View(objModeloCita);

        }

        [HttpPost]
        public IActionResult Pedir(AppointmentManager cita)
        {
            string user = HttpContext.Session.GetString("usuarioActivo");

            if (!userData.IsVerified(user))
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



            cita.BrandList = conexionMarca.MostrarMarcas();

            respuestaUsuario = conexionUsuario.MostrarUsuario(cita.CurrentUser);

            string existeUsuario = respuestaUsuario.UserName;

            if (string.IsNullOrEmpty(existeUsuario))
            {
                logger.Error("Se ha intentado crear una cita con un Name de UserEntity no valido, el Name del intento ha sido: " + cita.CurrentUser);
                HttpContext.Session.SetInt32("errorCita", 1);
                return View(cita);
            }
            else
            {
                conexionCita.NuevaCita(cita.Date, actual, cita.CurrentUser, "Aceptada", cita.Brand.Id, cita.Description);

                logger.Info("Se ha creado una cita a Name de " + cita.CurrentUser);

                return RedirectToAction("Listbikes", "Bikes");
            }


        }


    }
}
