using Bicistock.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Bicistock.Controllers
{
    public class ApiController : Controller
    {

        public string ConsultaCitas()
        {
            Logger.Logger logger = new Logger.Logger();

            AppointmentService conexionCita = new AppointmentService();

            return JsonSerializer.Serialize(conexionCita.MostrarCitas());
        }

    }
}
