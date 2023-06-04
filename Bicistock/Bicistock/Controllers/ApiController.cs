using Bicistock.Common.Models;
using Bicistock.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Bicistock.Controllers
{
    public class ApiController : Controller
    {
        public ActionResult<string> ConsultaCitas()
        {
            Logger.Logger logger = new Logger.Logger();

            AppointmentService conexionCita = new AppointmentService();

            return Ok(JsonSerializer.Serialize(conexionCita.MostrarCitas()));
        }

        [HttpPost]
        public ActionResult Authenticate(LoginFormModel model)
        {
            if (model.Username == "hola") 
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
    