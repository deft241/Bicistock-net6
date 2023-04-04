using Bicistock.Common.Models;
using Bicistock.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Bicistock.Controllers
{

    public class CitaController : Controller
    {
        CN_Usuario userData = new CN_Usuario();

        public IActionResult Pedir()
        {
            string user = HttpContext.Session.GetString("usuarioActivo");

            //if (!userData.IsVerified(user)) 
            //{
            //    return RedirectToAction("Index","Home");
            //}

            CN_Marca conexionMarca = new CN_Marca();
            CS_Marca Brand = new CS_Marca();
            CS_ModeloCita objModeloCita = new CS_ModeloCita();

            objModeloCita.BrandList = conexionMarca.MostrarMarcas();
            return View(objModeloCita);

        }

        [HttpPost]
        public IActionResult Pedir(CS_ModeloCita cita)
        {
            string user = HttpContext.Session.GetString("usuarioActivo");

            if (!userData.IsVerified(user))
            {
                return RedirectToAction("Index", "Home");
            }
            Logger.Logger logger = new Logger.Logger();
            DateTime actual = new DateTime();
            actual = DateTime.Now;
            CN_Marca conexionMarca = new CN_Marca();
            CN_Cita conexionCita = new CN_Cita();
            CN_Usuario conexionUsuario = new CN_Usuario();
            CS_Usuario respuestaUsuario = new CS_Usuario();

            CS_ModeloCita objModeloCita = new CS_ModeloCita();



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
