using Bicistock.Common.Models;
using Bicistock.Domain;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;

namespace Bicistock.Controllers
{
    public class PDFController : Controller
    {
        private IWebHostEnvironment Environment;

        public PDFController(IWebHostEnvironment _environment)
        {
            Environment = _environment;
        }

        public IActionResult Panel()
        {
            Logger.Logger logger = new Logger.Logger();

            CN_Usuario UserEntity = new CN_Usuario();
            CS_ModeloGeneral modeloGeneral = new CS_ModeloGeneral();
            CS_ModeloAdminPanel objAdminPanel = new CS_ModeloAdminPanel();
            objAdminPanel.UserList = UserEntity.MostrarUsuarios();


            logger.Info("Se ha generado un PDF de la lista de usuarios existentes");
            return new ViewAsPdf("Panel", objAdminPanel);


        }

        public IActionResult Citas()
        {
            Logger.Logger logger = new Logger.Logger();

            CN_Cita conexionCita = new CN_Cita();
            CS_ModeloCita objModeloCita = new CS_ModeloCita();
            CN_Marca conexionMarca = new CN_Marca();
            List<CS_Marca> marcas = new List<CS_Marca>();

            objModeloCita.CitationList = conexionCita.MostrarCitas();

            logger.Info("Se ha generado un PDF de la lista citas");


            return new ViewAsPdf("Citas", objModeloCita);
        }


        public IActionResult Productos()
        {
            Logger.Logger logger = new Logger.Logger();

            CN_Bici conexionBici = new CN_Bici();
            CN_Componente conexionComponente = new CN_Componente();

            CS_ModeloGeneral objModeloGeneral = new CS_ModeloGeneral();

            objModeloGeneral.BikeList = conexionBici.BiciMarca();
            objModeloGeneral.ComponentList = conexionComponente.MostrarComponente();

            logger.Info("Se ha generado un PDF de la lista de productos");

            return new ViewAsPdf("Productos", objModeloGeneral);
        }

    }
}