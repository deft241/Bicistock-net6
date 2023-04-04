using Bicistock.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Bicistock.Controllers
{
    public class ApiController : Controller
    {

        public string ConsultaCitas()
        {
            Logger.Logger logger = new Logger.Logger();

            CN_Cita conexionCita = new CN_Cita();

            return JsonSerializer.Serialize(conexionCita.MostrarCitas());
        }

    }
}
